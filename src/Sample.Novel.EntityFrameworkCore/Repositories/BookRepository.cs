using Microsoft.EntityFrameworkCore;
using Sample.Novel.Domain.Book.Entities;
using Sample.Novel.Domain.Book.Repository;
using Sample.Novel.EntityFrameworkCore.EntityFrameworkCore;
using Sample.Novel.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.EntityFrameworkCore.Repositories
{
    public class BookRepository : EfCoreRepository<NovelDbContext, Book, Guid>, IBookRepository
    {
        public BookRepository(IDbContextProvider<NovelDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Chapter> FindChapterByIdAsync(Guid id, bool include, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();
            var result = await dbContext.Chapters.IncludeIf(include, chapter => chapter.ChapterText)
                   .FirstOrDefaultAsync(f => f.Id == id, GetCancellationToken(cancellationToken));
            return result;
        }
        public override async Task<IQueryable<Book>> WithDetailsAsync()
        {
            var queryable = await GetQueryableAsync();
            return queryable.IncludeDetails(); // Uses the extension method defined above
        }

    }
}
