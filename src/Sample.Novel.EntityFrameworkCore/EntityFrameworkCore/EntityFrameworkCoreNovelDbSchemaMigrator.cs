using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sample.Novel.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Sample.Novel.EntityFrameworkCore.EntityFrameworkCore
{
    public class EntityFrameworkCoreNovelDbSchemaMigrator : INovelDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;
        public EntityFrameworkCoreNovelDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task MigrateAsync()
        {
            await _serviceProvider
             .GetRequiredService<NovelDbContext>()
             .Database
             .MigrateAsync();
        }
    }
}
