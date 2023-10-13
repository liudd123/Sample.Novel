using Sample.Novel.Application.Contracts.Dtos;
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
