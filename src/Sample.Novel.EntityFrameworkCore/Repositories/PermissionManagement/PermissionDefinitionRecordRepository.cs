using Microsoft.EntityFrameworkCore;
using Sample.Novel.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.PermissionManagement
{
    internal class PermissionDefinitionRecordRepository :EfCoreRepository<NovelDbContext, PermissionDefinitionRecord, Guid>,IPermissionDefinitionRecordRepository
    {
        public PermissionDefinitionRecordRepository(IDbContextProvider<NovelDbContext> dbContextProvider): base(dbContextProvider)
        {
        }

        public virtual async Task<PermissionDefinitionRecord> FindByNameAsync(string name,CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .OrderBy(x => x.Id)
                .FirstOrDefaultAsync(r => r.Name == name, cancellationToken);
        }
    }
}
