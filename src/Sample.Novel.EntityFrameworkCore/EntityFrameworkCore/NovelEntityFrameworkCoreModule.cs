using Microsoft.Extensions.DependencyInjection;
using Sample.Novel.Domain.Author.Entities;
using Sample.Novel.Domain.Book.Entities;
using Sample.Novel.Domain.Category.Entities;
using Sample.Novel.EntityFrameworkCore.EntityFrameworkCore;
using Sample.Novel.EntityFrameworkCore.Repositories.Authors;
using Sample.Novel.EntityFrameworkCore.Repositories.Books;
using Sample.Novel.EntityFrameworkCore.Repositories.Categories;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace Sample.Novel.EntityFrameworkCore
{
    [DependsOn(typeof(NovelDomainModule),
        typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule))]
    public class NovelEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<NovelDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories(includeAllEntities: true);


                options.AddRepository<Book, BookRepository>();
                options.AddRepository<Author, AuthorRepository>();
                options.AddRepository<Category, CategoryRepository>();
            });
            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also NovelMigrationsDbContextFactory for EF Core tooling. */
                options.UseSqlServer();
            });
        }
    }
}
