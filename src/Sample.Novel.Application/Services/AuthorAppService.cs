using Sample.Novel.Application.Contracts.Dtos.Author;
using Sample.Novel.Application.Contracts.Interfaces;
using Sample.Novel.Domain.Author.Entities;
using Sample.Novel.Domain.Author.Repository;
using System.Linq.Dynamic.Core;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Sample.Novel.Application.Services
{
    public class AuthorAppService : ApplicationService, IAuthorAppService
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorAppService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        public async Task CreateAsync(CreateAuthorInput input)
        {

            var author = ObjectMapper.Map<CreateAuthorInput, Author>(input);
            await authorRepository.InsertAsync(author);


        }

        public async Task<AuthorDto> GetAsync(Guid id)
        {
            var author = await authorRepository.GetAsync(id);
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        public async Task<PagedResultDto<AuthorDto>> GetListAsnyc(PagedAndSortedResultRequestDto input)
        {
            var queryable = await authorRepository.GetQueryableAsync();
            queryable.Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .OrderBy(input.Sorting ?? nameof(Author.Name));
            List<Author> authors = await AsyncExecuter.ToListAsync(queryable);
            var count = await authorRepository.GetCountAsync();
            var subjectDtos = ObjectMapper.Map<List<Author>, List<AuthorDto>>(authors);
            return new PagedResultDto<AuthorDto>(count, subjectDtos);
        }
    }
}
