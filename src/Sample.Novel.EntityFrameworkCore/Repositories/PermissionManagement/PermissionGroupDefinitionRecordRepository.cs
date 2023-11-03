using Sample.Novel.EntityFrameworkCore.EntityFrameworkCore;
using Sample.Novel.PermissionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.PermissionManagement
{
    public class PermissionGroupDefinitionRecordRepository :EfCoreRepository<NovelDbContext, PermissionGroupDefinitionRecord, Guid>,IPermissionGroupDefinitionRecordRepository
    {
        public PermissionGroupDefinitionRecordRepository(IDbContextProvider<NovelDbContext> dbContextProvider): base(dbContextProvider)
        {
        }
    }
}
