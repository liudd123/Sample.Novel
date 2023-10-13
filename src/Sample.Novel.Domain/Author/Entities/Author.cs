using JetBrains.Annotations;
using Sample.Novel.Domain.Shared.Author;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.Author.Entities
{
    public class Author : Entity<Guid>
    {
        [MaxLength(AuthorConsts.MaxNameLength)]
        [Required]
        public string Name { get; set; }
        [MaxLength(AuthorConsts.MaxDescriptionLength)]
        public string Description { get; set; }
        protected Author() { }

        public Author(Guid id, [NotNull] string name, [CanBeNull] string description)
        {
            Id = id;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Description = description;
        }
    }
}
