using Volo.Abp.Modularity;

namespace Sample.Novel
{
    [DependsOn(typeof(NovelDomainSharedModule))]
    public class NovelApplicationContractsModule:AbpModule
    {
    }
}
