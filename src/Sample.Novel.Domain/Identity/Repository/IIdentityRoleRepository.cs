using Sample.Novel.Domain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sample.Novel.Domain.Identity.Repository
{
    public interface IIdentityRoleRepository:IRepository<IdentityRole,Guid>
    {
        Task<List<IdentityRoleWithUserCount>> GetListWithUserCountAsync(
        string sorting = null,
        int maxResultCount = int.MaxValue,
        int skipCount = 0,
        string filter = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default
    );

        Task<List<IdentityRole>> GetListAsync(
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );
        Task<List<IdentityRole>> GetListAsync(
            IEnumerable<Guid> ids,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filter = null,
            CancellationToken cancellationToken = default
        );
        Task<List<IdentityRole>> GetDefaultRolesAsync();
    }
}
