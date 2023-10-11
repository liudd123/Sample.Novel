using JetBrains.Annotations;
using Sample.Novel.Domain.Shared.Category;
using System.ComponentModel.DataAnnotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.Category.Entities
{
    public class Category : Entity<Guid>
    {
        [MaxLength(CategoryConsts.MaxNameLength)]
        public string Name { get; set; }
        protected Category()
        {

        }
        public Category(Guid id, [NotNull] string name)
        {
            Id = id;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }
    }
}
