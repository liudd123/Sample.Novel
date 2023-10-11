using Microsoft.EntityFrameworkCore;
using Sample.Novel.Domain.Book.Entities;
using Sample.Novel.Domain.Book.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Threading;

namespace Sample.Novel.EntityFrameworkCore.Extensions
{
    public static class BookRepostoryExtension
    {
        public static Chapter FindChapterById(this IBookRepository bookRepository, Guid id, bool include)
        {
            return AsyncHelper.RunSync(() => bookRepository.FindChapterByIdAsync(id, include));

        }
        public static IQueryable<Book> IncludeDetails(this IQueryable<Book> queryable, bool include = true)
        {
            if (!include) return queryable;
            return queryable.Include(book => book.Volumes)
                .ThenInclude(volume => volume.Chapters);
        }
    }
}
