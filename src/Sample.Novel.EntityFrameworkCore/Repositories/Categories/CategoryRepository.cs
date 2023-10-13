using Sample.Novel.Domain.Category.Entities;
using Sample.Novel.Domain.Category.Repository;
using Sample.Novel.EntityFrameworkCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.EntityFrameworkCore.Repositories
{
    public class CategoryRepository : EfCoreRepository<NovelDbContext, Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<NovelDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
