using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.Identity.Entities
{
    public class IdentityUserRole : Entity
    {
        /// <summary>
        /// Gets or sets the primary key of the user that is linked to a role.
        /// </summary>
        public virtual Guid UserId { get; protected set; }

        /// <summary>
        /// Gets or sets the primary key of the role that is linked to the user.
        /// </summary>
        public virtual Guid RoleId { get; protected set; }

        protected IdentityUserRole()
        {

        }

        protected internal IdentityUserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
        public override object[] GetKeys()
        {
            return new object[] { UserId, RoleId };
        }
    }
}
