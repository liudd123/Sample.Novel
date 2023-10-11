using Sample.Novel.Application.Contracts.Dtos.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Sample.Novel.Application.Contracts.Interfaces
{
    public interface IAuthorAppService : IApplicationService
    {
        Task CreateAsync(CreateAuthorInput input);
        Task<AuthorDto> GetAsync(Guid id);
        Task<PagedResultDto<AuthorDto>> GetListAsnyc(PagedAndSortedResultRequestDto input);
    }
}
