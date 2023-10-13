using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Sample.Novel
{
    [DependsOn(typeof(NovelDomainSharedModule),
        typeof(AbpIdentityApplicationContractsModule))]
    public class NovelApplicationContractsModule:AbpModule
    {
    }
}
