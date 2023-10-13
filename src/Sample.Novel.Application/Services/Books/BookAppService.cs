using Sample.Novel.Application.Contracts.Dtos.Book;
using Sample.Novel.Application.Contracts.Interfaces;
using Sample.Novel.Domain.Author.Entities;
using Sample.Novel.Domain.Book.Entities;
using Sample.Novel.Domain.Book.Repository;
using System.Linq.Dynamic.Core;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
namespace Sample.Novel.Application.Services.Books
{
    public class BookAppService : ApplicationService, IBookAppService
    {
        private readonly IBookRepository bookRepository;

        public BookAppService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public async Task CreateBookAsync(CreateBookInput input)
        {
            var book = ObjectMapper.Map<CreateBookInput, Book>(input);

            await bookRepository.InsertAsync(book);
        }

        public async Task<BookDto> GetBookAsync(Guid id)
        {
            var book = await bookRepository.GetAsync(id);
            return ObjectMapper.Map<Book, BookDto>(book);
        }

        public async Task<PagedResultDto<BookDto>> GetBookListAsnyc(PagedAndSortedResultRequestDto input)
        {
            var queryable = await bookRepository.GetQueryableAsync();
            queryable.Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .OrderBy(input.Sorting ?? nameof(Author.Name));
            List<Book> books = await AsyncExecuter.ToListAsync(queryable);
            var count = await bookRepository.GetCountAsync();
            var bookDtos = ObjectMapper.Map<List<Book>, List<BookDto>>(books);
            return new PagedResultDto<BookDto>(count, bookDtos);
        }
    }
}
