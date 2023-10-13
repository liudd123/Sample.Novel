using Sample.Novel.Application.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Sample.Novel.Application.Contracts.Interfaces
{
    public interface IRoleAppService : IApplicationService
    {
        Task CreateAsync(IdentityRoleCreateOrUpdateInput input);
        Task<IdentityRoleDto> GetAsync(Guid id);
        Task<PagedResultDto<IdentityRoleDto>> GetListAsnyc(PagedAndSortedResultRequestDto input);
    }
}
