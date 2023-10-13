using Microsoft.AspNetCore.Mvc;
using Sample.Novel.Application.Contracts.Dtos.Author;
using Sample.Novel.Application.Contracts.Interfaces;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Sample.Novel.HttpApi.Host.Controllers
{
    [ControllerName("Author(作者)")]
    [Route("api/[controller]/[action]")]
    public class AuthorController : AbpControllerBase, IAuthorAppService
    {
        private readonly IAuthorAppService authorAppService;

        public AuthorController(IAuthorAppService authorAppService)
        {
            this.authorAppService = authorAppService;
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task CreateAsync(CreateAuthorInput input)
        {
            await authorAppService.CreateAsync(input);
        }
        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<AuthorDto> GetAsync(Guid id)
        {
            return await authorAppService.GetAsync(id);
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedResultDto<AuthorDto>> GetListAsnyc(PagedAndSortedResultRequestDto input)
        {
            return await authorAppService.GetListAsnyc(input);
        }
    }
}
