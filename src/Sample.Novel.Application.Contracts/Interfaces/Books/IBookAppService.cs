using Sample.Novel.Application.Contracts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Sample.Novel.Application.Contracts.Interfaces
{
    public interface IBookAppService : IApplicationService
    {
        Task CreateBookAsync(CreateBookInput input);
        Task<BookDto> GetBookAsync(Guid id);
        Task<PagedResultDto<BookDto>> GetBookListAsnyc(PagedAndSortedResultRequestDto input);
    }
}
