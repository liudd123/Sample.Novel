using Sample.Novel.Application.Contracts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Sample.Novel.Application.Contracts.Interfaces
{
    public interface ICategoryAppService : IApplicationService
    {
        Task CreateAsync(CreateCategoryInput input);
        Task<CategoryDto> GetAsync(Guid id);
        Task<PagedResultDto<CategoryDto>> GetListAsnyc(PagedAndSortedResultRequestDto input);
    }
}
