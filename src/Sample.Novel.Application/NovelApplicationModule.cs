using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Sample.Novel
{
    [DependsOn(typeof(NovelDomainModule),
    typeof(AbpIdentityApplicationModule),
        typeof(NovelApplicationContractsModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]
    public class NovelApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<NovelApplicationModule>();
            });
        }
    }
}
