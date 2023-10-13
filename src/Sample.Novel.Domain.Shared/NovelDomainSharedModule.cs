using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Sample.Novel
{
    [DependsOn(typeof(AbpIdentityDomainSharedModule))]
    public class NovelDomainSharedModule:AbpModule
    {
    }
}
