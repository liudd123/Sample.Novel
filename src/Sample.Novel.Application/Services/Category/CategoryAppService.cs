using Sample.Novel.Application.Contracts.Dtos.Category;
using Sample.Novel.Application.Contracts.Interfaces;
using Sample.Novel.Domain.Category.Entities;
using Sample.Novel.Domain.Category.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;
using System.Linq.Dynamic.Core;
using Sample.Novel.Application.Contracts.Dtos.Author;
using Sample.Novel.Domain.Author.Entities;

namespace Sample.Novel.Application.Services.Category
{
    public class CategoryAppService : ApplicationService, ICategoryAppService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryAppService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        /// <summary>
        /// 创建分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateAsync(CreateCategoryInput input)
        {
            var category = ObjectMapper.Map<CreateCategoryInput, Category>(input);
            await categoryRepository.InsertAsync(category);
        }
        /// <summary>
        /// 根据id查询分类详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns>CategoryDto</returns>
        public async Task<CategoryDto> GetAsync(Guid id)
        {
            var category = await categoryRepository.GetAsync(id);
            return ObjectMapper.Map<Category, CategoryDto>(category);
        }
        /// <summary>
        /// 分页查询分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<PagedResultDto<CategoryDto>> GetListAsnyc(PagedAndSortedResultRequestDto input)
        {
            var queryable = await categoryRepository.GetQueryableAsync();
            queryable.Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .OrderBy(input.Sorting ?? nameof(Author.Name));
            List<Category> categorys = await AsyncExecuter.ToListAsync(queryable);
            var count = await categoryRepository.GetCountAsync();
            var categoryDtos = ObjectMapper.Map<List<Category>, List<CategoryDto>>(categorys);
            return new PagedResultDto<CategoryDto>(count, categoryDtos);
        }
    }
}
