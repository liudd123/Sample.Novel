using Microsoft.EntityFrameworkCore;
using Sample.Novel.Domain.Identity.Entities;
using Sample.Novel.Domain.Identity.Repository;
using Sample.Novel.EntityFrameworkCore.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.EntityFrameworkCore.Repositories
{
    public class IdentityRoleRepository : EfCoreRepository<NovelDbContext, IdentityRole, Guid>, IIdentityRoleRepository
    {
        public IdentityRoleRepository(IDbContextProvider<NovelDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<long> GetCountAsync(
        string filter = null,
        CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .WhereIf(!filter.IsNullOrWhiteSpace(),
                    x => x.Name.Contains(filter))
                .LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<IdentityRole>> GetListAsync(
      string sorting = null,
      int maxResultCount = int.MaxValue,
      int skipCount = 0,
      string filter = null,
      bool includeDetails = true,
      CancellationToken cancellationToken = default)
        {
            return await GetListInternalAsync(sorting, maxResultCount, skipCount, filter, includeDetails, cancellationToken);
        }

        public virtual async Task<List<IdentityRole>> GetListAsync(
            IEnumerable<Guid> ids,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .Where(t => ids.Contains(t.Id))
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<IdentityRoleWithUserCount>> GetListWithUserCountAsync(
     string sorting = null,
     int maxResultCount = int.MaxValue,
     int skipCount = 0,
     string filter = null,
     bool includeDetails = false,
     CancellationToken cancellationToken = default)
        {
            var roles = await GetListInternalAsync(sorting, maxResultCount, skipCount, filter, includeDetails, cancellationToken: cancellationToken);

            var roleIds = roles.Select(x => x.Id).ToList();
            var userCount = await (await GetDbContextAsync()).Set<IdentityUserRole>()
                .Where(userRole => roleIds.Contains(userRole.RoleId))
                .GroupBy(userRole => userRole.RoleId)
                .Select(x => new
                {
                    RoleId = x.Key,
                    Count = x.Count()
                })
                .ToListAsync(GetCancellationToken(cancellationToken));

            return roles.Select(role => new IdentityRoleWithUserCount(role, userCount.FirstOrDefault(x => x.RoleId == role.Id)?.Count ?? 0)).ToList();
        }

        protected virtual async Task<List<IdentityRole>> GetListInternalAsync(
        string sorting = null,
        int maxResultCount = int.MaxValue,
        int skipCount = 0,
        string filter = null,
        bool includeDetails = true,
        CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .WhereIf(!filter.IsNullOrWhiteSpace(),
                    x => x.Name.Contains(filter))
                .OrderBy(sorting.IsNullOrWhiteSpace() ? nameof(IdentityRole.Name) : sorting)
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}
