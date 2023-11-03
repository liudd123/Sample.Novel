using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Sample.Novel.Domain.Shared;
using Sample.Novel.Domain.Shared.Result;
using Sample.Novel.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Volo.Abp;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace Sample.Novel
{
    [DependsOn(
        typeof(AbpSwashbuckleModule),
        typeof(NovelApplicationModule),
        typeof(NovelEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpAutofacModule)
        )
        ]
    public class NovelHttpApiHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            context.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;//解决后端传到前端全大写
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);//解决后端返回数据中文被编码
            }); ;
            ConfigureConventionalControllers();
            ConfigureSwaggerServices(context, configuration);

            ConfiguraJwt(context, configuration);
        }
        private void ConfigureConventionalControllers()
        {
            //Configure<AbpAspNetCoreMvcOptions>(options =>
            //{
            //});
        }
        private void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAbpSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Nocel API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);

                var xmlDto = Path.Combine(AppContext.BaseDirectory, "Sample.Novel.Application.Contracts.xml");
                options.IncludeXmlComments(xmlDto);

                var xmlControllers = Path.Combine(AppContext.BaseDirectory, "Sample.Novel.HttpApi.Host.xml");
                options.IncludeXmlComments(xmlControllers);

                #region swagger 用 Jwt验证
                //开启权限小锁
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                //在header中添加token，传递到后台
                options.OperationFilter<SecurityRequirementsOperationFilter>();
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传递)直接在下面框中输入Bearer {token}(注意两者之间是一个空格) \"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
                #endregion
            });
        }

        private void ConfiguraJwt(ServiceConfigurationContext context, IConfiguration configuration)
        {
            var jwtOption = context.Services.GetRequiredService<IOptions<JwtOption>>().Value;

            //var myConfiguration = configuration.GetSection(JwtOption.JWT);
            //context.Services.Configure<JwtOption>(myConfiguration);
            //var jwtOption = myConfiguration.Get<JwtOption>();
            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateIssuerSigningKey = true,
                     ValidAudience = jwtOption.ValidAudience,//订阅人
                     ValidIssuer = jwtOption.ValidIssuer,//发行人
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOption.IssuerSigningKey))//加密Key
                 };
                 options.Events = new JwtBearerEvents
                 {
                     OnChallenge = async context =>
                     {
                         context.HandleResponse();

                         context.Response.ContentType = "application/json;charset=utf-8";
                         context.Response.StatusCode = StatusCodes.Status200OK;

                         var result = ApiResponse.Error("未登录", StatusCode.NoLogin);

                         //改成统一返回值
                         await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
                     },
                     OnAuthenticationFailed = context =>
                     {
                         var jwtHandler = new JwtSecurityTokenHandler();
                         var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                         if (!string.IsNullOrEmpty(token) && jwtHandler.CanReadToken(token))
                         {
                             var jwtToken = jwtHandler.ReadJwtToken(token);

                             if (jwtToken.Issuer != jwtOption.ValidIssuer)
                             {
                                 context.Response.Headers.Add("Token-Error-Iss", "issuer is wrong!");
                             }

                             if (jwtToken.Audiences.FirstOrDefault() != jwtOption.ValidAudience)
                             {
                                 context.Response.Headers.Add("Token-Error-Aud", "Audience is wrong!");
                             }
                         }
                         // 如果过期，则把<是否过期>添加到，返回头信息中
                         if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                         {
                             context.Response.Headers.Add("Token-Expired", "true");
                         }
                         return Task.CompletedTask;
                     },
                     OnForbidden=async context => {
                         context.Success();

                         context.Response.ContentType = "application/json;charset=utf-8";
                         context.Response.StatusCode = StatusCodes.Status200OK;

                         var result = ApiResponse.Error("没权限操作", StatusCode.NoPermissions);

                         //改成统一返回值
                         await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
                     }
                 };
             });
            context.Services.AddAuthorization();
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseAbpSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Novel API");
                });
            }

            if (!env.IsDevelopment())
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles();

            app.UseRouting();
            // 先开启认证
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();
        }
    }
}
