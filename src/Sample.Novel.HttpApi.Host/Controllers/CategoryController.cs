using Microsoft.AspNetCore.Mvc;
using Sample.Novel.Application.Contracts.Dtos;
using Sample.Novel.Application.Contracts.Interfaces;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Sample.Novel.HttpApi.Host.Controllers
{
    [ControllerName("Category(分类)")]
    [Route("api/[controller]/[action]")]
    public class CategoryController : AbpControllerBase, ICategoryAppService
    {
        private readonly ICategoryAppService categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            this.categoryAppService = categoryAppService;
        }
        /// <summary>
        /// 创建分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task CreateAsync(CreateCategoryInput input)
        {
            await categoryAppService.CreateAsync(input);
        }
        /// <summary>
        /// 根据id获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<CategoryDto> GetAsync(Guid id)
        {
            return await categoryAppService.GetAsync(id);
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedResultDto<CategoryDto>> GetListAsnyc(PagedAndSortedResultRequestDto input)
        {
            return await categoryAppService.GetListAsnyc(input);
        }
    }
}
