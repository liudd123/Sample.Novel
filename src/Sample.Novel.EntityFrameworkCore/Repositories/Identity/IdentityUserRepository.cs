using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Sample.Novel.Domain.Identity.Entities;
using Sample.Novel.Domain.Identity.Repository;
using Sample.Novel.EntityFrameworkCore.EntityFrameworkCore;
using Sample.Novel.EntityFrameworkCore.Extensions;
using System.Linq;
using System.Linq.Dynamic.Core;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.EntityFrameworkCore.Repositories
{
    public class IdentityUserRepository : EfCoreRepository<NovelDbContext, IdentityUser, Guid>, IIdentityUserRepository
    {
        public IdentityUserRepository(IDbContextProvider<NovelDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<IdentityUser> FindByEmailAsync([NotNull] string email, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
            .IncludeDetails(includeDetails)
            .OrderBy(x => x.Id)
            .FirstOrDefaultAsync(u => u.Email == email, GetCancellationToken(cancellationToken));
        }

        public async Task<IdentityUser> FindByUserNameAsync([NotNull] string userName, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
           .IncludeDetails(includeDetails)
           .OrderBy(x => x.Id)
           .FirstOrDefaultAsync(
               u => u.UserName == userName,
               GetCancellationToken(cancellationToken)
           );
        }

        public virtual async Task<long> GetCountAsync(
        string filter = null,
        Guid? roleId = null,
        string userName = null,
        string phoneNumber = null,
        string emailAddress = null,
        string name = null,
        bool? isLockedOut = null,
        bool? notActive = null,
        bool? emailConfirmed = null,
        DateTime? maxCreationTime = null,
        DateTime? minCreationTime = null,
        DateTime? maxModifitionTime = null,
        DateTime? minModifitionTime = null,
        CancellationToken cancellationToken = default)
        {
            var upperFilter = filter?.ToUpperInvariant();
            return await (await GetDbSetAsync())
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    u => u.Name != null && u.Name.Contains(filter)
                )
                .WhereIf(roleId.HasValue, identityUser => identityUser.Roles.Any(x => x.RoleId == roleId.Value))
                .WhereIf(!string.IsNullOrWhiteSpace(userName), x => x.UserName == userName)
                .WhereIf(!string.IsNullOrWhiteSpace(phoneNumber), x => x.PhoneNumber == phoneNumber)
                .WhereIf(!string.IsNullOrWhiteSpace(emailAddress), x => x.Email == emailAddress)
                .WhereIf(!string.IsNullOrWhiteSpace(name), x => x.Name == name)
                .WhereIf(isLockedOut.HasValue, x => (x.LockoutEnabled && x.LockoutEnd.HasValue && x.LockoutEnd.Value.CompareTo(DateTime.UtcNow) > 0) == isLockedOut.Value)
                .WhereIf(notActive.HasValue, x => x.IsActive == !notActive.Value)
                .WhereIf(emailConfirmed.HasValue, x => x.EmailConfirmed == emailConfirmed.Value)
                .WhereIf(maxCreationTime != null, p => p.CreationTime <= maxCreationTime)
                .WhereIf(minCreationTime != null, p => p.CreationTime >= minCreationTime)
                .WhereIf(maxModifitionTime != null, p => p.LastModificationTime <= maxModifitionTime)
                .WhereIf(minModifitionTime != null, p => p.LastModificationTime >= minModifitionTime)
                .LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<IdentityUser>> GetListAsync(
        string sorting = null,
        int maxResultCount = int.MaxValue,
        int skipCount = 0,
        string filter = null,
        bool includeDetails = false,
        Guid? roleId = null,
        string userName = null,
        string phoneNumber = null,
        string emailAddress = null,
        string name = null,
        bool? isLockedOut = null,
        bool? notActive = null,
        bool? emailConfirmed = null,
        DateTime? maxCreationTime = null,
        DateTime? minCreationTime = null,
        DateTime? maxModifitionTime = null,
        DateTime? minModifitionTime = null,
        CancellationToken cancellationToken = default)
        {
            var upperFilter = filter?.ToUpperInvariant();
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetails)
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    u =>
                        (u.Name != null && u.Name.Contains(filter)) ||
                        (u.PhoneNumber != null && u.PhoneNumber.Contains(filter))
                )
                .WhereIf(roleId.HasValue, identityUser => identityUser.Roles.Any(x => x.RoleId == roleId.Value))
                .WhereIf(!string.IsNullOrWhiteSpace(userName), x => x.UserName.Contains(userName))
                .WhereIf(!string.IsNullOrWhiteSpace(phoneNumber), x => x.PhoneNumber.Contains(phoneNumber))
                .WhereIf(!string.IsNullOrWhiteSpace(emailAddress), x => x.Email.Contains(emailAddress))
                .WhereIf(!string.IsNullOrWhiteSpace(name), x => x.Name.Contains(name))
                .WhereIf(isLockedOut.HasValue, x => (x.LockoutEnabled && x.LockoutEnd.HasValue && x.LockoutEnd.Value.CompareTo(DateTime.UtcNow) > 0) == isLockedOut.Value)
                .WhereIf(notActive.HasValue, x => x.IsActive == !notActive.Value)
                .WhereIf(emailConfirmed.HasValue, x => x.EmailConfirmed == emailConfirmed.Value)
                .WhereIf(maxCreationTime != null, p => p.CreationTime <= maxCreationTime)
                .WhereIf(minCreationTime != null, p => p.CreationTime >= minCreationTime)
                .WhereIf(maxModifitionTime != null, p => p.LastModificationTime <= maxModifitionTime)
                .WhereIf(minModifitionTime != null, p => p.LastModificationTime >= minModifitionTime)
                .OrderBy(sorting.IsNullOrWhiteSpace() ? nameof(IdentityUser.UserName) : sorting)
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<IdentityUser>> GetListByIdsAsync(IEnumerable<Guid> ids, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetails)
                .Where(x => ids.Contains(x.Id))
                .ToListAsync(GetCancellationToken(cancellationToken));
        }


        public virtual async Task<List<string>> GetRoleNamesAsync(
        Guid id,
        CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();
            var query = from userRole in dbContext.Set<IdentityUserRole>()
                        join role in dbContext.Roles on userRole.RoleId equals role.Id
                        where userRole.UserId == id
                        select role.Name;

            return await query.ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<IdentityRole>> GetRolesAsync(
       Guid id,
       bool includeDetails = false,
       CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();

            var query = from userRole in dbContext.Set<IdentityUserRole>()
                        join role in dbContext.Roles on userRole.RoleId equals role.Id
                        where userRole.UserId == id
                        select role;

            return await query.ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task RemoveRoles(Guid userId, List<Guid> roleIds)
        {
            var dbContext = await GetDbContextAsync();
            var UserRoles = dbContext.Set<IdentityUserRole>();
            var list = await UserRoles.Where(w => w.UserId == userId && roleIds.Contains(w.RoleId)).ToListAsync();
            UserRoles.RemoveRange(list);
        }
        public async Task AddRolesAsync(IEnumerable<IdentityUserRole> userRoles)
        {
            var dbContext = await GetDbContextAsync();
            var UserRoles = dbContext.Set<IdentityUserRole>();
            UserRoles.AddRange(userRoles);
        }
    }
}
