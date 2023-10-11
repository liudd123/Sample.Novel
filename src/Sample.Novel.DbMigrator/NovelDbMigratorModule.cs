using Sample.Novel.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Sample.Novel.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(NovelEntityFrameworkCoreModule),
        typeof(NovelApplicationContractsModule)
    )]
    public class NovelDbMigratorModule : AbpModule
    {
    }
}
