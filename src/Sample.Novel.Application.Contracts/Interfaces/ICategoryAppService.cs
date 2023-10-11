using Sample.Novel.Application.Contracts.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Sample.Novel.Application.Contracts.Interfaces
{
    public interface ICategoryAppService:IApplicationService
    {
        Task CreateAsync(CreateCategoryInput input);
        Task<CategoryDto> GetAsync(Guid id);
        Task<PagedResultDto<CategoryDto>> GetListAsnyc(PagedAndSortedResultRequestDto input);
    }
}
