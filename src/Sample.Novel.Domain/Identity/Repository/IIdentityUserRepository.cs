using JetBrains.Annotations;
using Sample.Novel.Domain.Identity.Entities;
using Volo.Abp.Domain.Repositories;

namespace Sample.Novel.Domain.Identity.Repository
{
    public interface IIdentityUserRepository : IRepository<IdentityUser, Guid>
    {
        Task<IdentityUser> FindByUserNameAsync(
            [NotNull] string userName,
            bool includeDetails = true,
            CancellationToken cancellationToken = default
        );
        Task<IdentityUser> FindByEmailAsync(
           [NotNull] string email,
           bool includeDetails = true,
           CancellationToken cancellationToken = default
       );
        Task<List<string>> GetRoleNamesAsync(
        Guid id,
        CancellationToken cancellationToken = default);

        Task<List<IdentityUser>> GetListAsync(
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
        CancellationToken cancellationToken = default);

        Task<List<IdentityRole>> GetRolesAsync(
            Guid id,
            bool includeDetails = false,
            CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
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
        CancellationToken cancellationToken = default
    );
        Task<List<IdentityUser>> GetListByIdsAsync(
        IEnumerable<Guid> ids,
        bool includeDetails = false,
        CancellationToken cancellationToken = default
    );
        Task RemoveRoles(Guid userId, List<Guid> roleIds);
        Task AddRolesAsync(IEnumerable<IdentityUserRole> userRoles);

        Task<IdentityUser> LoginAsync(string userName, string passwordHash);
    }
}
