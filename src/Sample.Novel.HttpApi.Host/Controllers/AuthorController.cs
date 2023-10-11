using Microsoft.AspNetCore.Mvc;
using Sample.Novel.Application.Contracts.Dtos.Author;
using Sample.Novel.Application.Contracts.Interfaces;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Sample.Novel.HttpApi.Host.Controllers
{
    [ControllerName("作者")]
    [Route("api/[controller]/[action]")]
    public class AuthorController : AbpControllerBase, IAuthorAppService
    {
        private readonly IAuthorAppService authorAppService;

        public AuthorController(IAuthorAppService authorAppService)
        {
            this.authorAppService = authorAppService;
        }
        [HttpPost]
        public async Task CreateAsync(CreateAuthorInput input)
        {
            await authorAppService.CreateAsync(input);
        }
        [HttpGet]
        public async Task<AuthorDto> GetAsync(Guid id)
        {
            return await authorAppService.GetAsync(id);
        }

        [HttpGet]
        public async Task<PagedResultDto<AuthorDto>> GetListAsnyc(PagedAndSortedResultRequestDto input)
        {
            return await authorAppService.GetListAsnyc(input);
        }
    }
}
