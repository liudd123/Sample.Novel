using Microsoft.EntityFrameworkCore;
using Sample.Novel.Domain.Author.Entities;
using Sample.Novel.Domain.Book.Entities;
using Sample.Novel.Domain.Category.Entities;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace Sample.Novel.EntityFrameworkCore.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(IIdentityDbContext))]
    [ConnectionStringName("Default")]
    public class NovelDbContext : AbpDbContext<NovelDbContext>, IIdentityDbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<ChapterText> ChapterTexts { get; set; }
        public DbSet<Volume> Volumes { get; set; }

        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        public DbSet<IdentityLinkUser> LinkUsers { get; set; }
        public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

        public NovelDbContext(DbContextOptions<NovelDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigureIdentity();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NovelDbContext).Assembly);
        }
    }
}
