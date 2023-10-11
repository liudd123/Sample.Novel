﻿using Microsoft.OpenApi.Models;
using Sample.Novel.EntityFrameworkCore;
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
            context.Services.AddControllers();
            ConfigureConventionalControllers();
            ConfigureSwaggerServices(context, configuration);
        }
        private void ConfigureConventionalControllers()
        {
            //Configure<AbpAspNetCoreMvcOptions>(options =>
            //{
            //});
        }
        private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAbpSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Nocel API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
            });
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseAbpSwaggerUI();
            }

            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();
        }
    }
}
