using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sample.Novel.Domain.Author.Repository
{
    public interface IAuthorRepository : IRepository<Entities.Author, Guid>
    {
    }
}
