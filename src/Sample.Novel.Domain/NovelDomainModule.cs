using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Sample.Novel
{
    [DependsOn(typeof(AbpIdentityDomainModule))]
    public class NovelDomainModule : AbpModule
    {
    }
}
