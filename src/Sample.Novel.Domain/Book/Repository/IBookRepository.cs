using Sample.Novel.Domain.Book.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sample.Novel.Domain.Book.Repository
{
    public interface IBookRepository : IRepository<Entities.Book, Guid>
    {
        Task<Chapter> FindChapterByIdAsync(Guid id, bool include, CancellationToken cancellationToken=default);
    }
}
