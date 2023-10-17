using JetBrains.Annotations;
using System.Collections.ObjectModel;
using System.Security.Claims;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Sample.Novel.Domain.Identity.Entities
{
    public class IdentityRole : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; protected internal set; }
        /// <summary>
        /// A static role can not be deleted/renamed
        /// </summary>
        public virtual bool IsStatic { get; set; }
        protected IdentityRole() { }

        public IdentityRole(Guid id, [NotNull] string name)
        {
            Check.NotNull(name, nameof(name));

            Id = id;
            Name = name;
        }
        public virtual void ChangeName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Name = name;

        }
    }
}
