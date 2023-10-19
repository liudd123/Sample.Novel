using JetBrains.Annotations;
using System.Collections.ObjectModel;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;

namespace Sample.Novel.Domain.Identity.Entities
{
    public class IdentityUser : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// Gets or sets the user name for this user.
        /// </summary>
        public virtual string UserName { get; protected internal set; }

        /// <summary>
        /// Gets or sets the Name for the user.
        /// </summary>
        [CanBeNull]
        public virtual string Name { get; protected internal set; }


        /// <summary>
        /// Gets or sets the email address for this user.
        /// </summary>
        public virtual string Email { get; protected internal set; }


        /// <summary>
        /// Gets or sets a flag indicating if a user has confirmed their email address.
        /// </summary>
        /// <value>True if the email address has been confirmed, otherwise false.</value>
        public virtual bool EmailConfirmed { get; protected internal set; }

        /// <summary>
        /// Gets or sets a salted and hashed representation of the password for this user.
        /// </summary>
        [DisableAuditing]
        public virtual string PasswordHash { get; protected internal set; }


        /// <summary>
        /// Gets or sets a telephone number for the user.
        /// </summary>
        [CanBeNull]
        public virtual string PhoneNumber { get; protected internal set; }

        /// <summary>
        /// Gets or sets a flag indicating if a user has confirmed their telephone address.
        /// </summary>
        /// <value>True if the telephone number has been confirmed, otherwise false.</value>
        public virtual bool PhoneNumberConfirmed { get; protected internal set; }

        /// <summary>
        /// Gets or sets a flag indicating if the user is active.
        /// </summary>
        public virtual bool IsActive { get; protected internal set; }

        /// <summary>
        /// Gets or sets the date and time, in UTC, when any user lockout ends.
        /// </summary>
        /// <remarks>
        /// A value in the past means the user is not locked out.
        /// </remarks>
        public virtual DateTimeOffset? LockoutEnd { get; protected internal set; }

        /// <summary>
        /// Gets or sets a flag indicating if the user could be locked out.
        /// </summary>
        /// <value>True if the user could be locked out, otherwise false.</value>
        public virtual bool LockoutEnabled { get; protected internal set; }

        /// <summary>
        /// Gets or sets the number of failed login attempts for the current user.
        /// </summary>
        public virtual int AccessFailedCount { get; protected internal set; }

        /// <summary>
        /// Should change password on next login.
        /// </summary>
        public virtual bool ShouldChangePasswordOnNextLogin { get; protected internal set; }

        /// <summary>
        /// Gets or sets the last password change time for the user.
        /// </summary>
        public virtual DateTimeOffset? LastPasswordChangeTime { get; protected set; }

        //TODO: Can we make collections readonly collection, which will provide encapsulation. But... can work for all ORMs?

        /// <summary>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        public virtual ICollection<IdentityUserRole> Roles { get; protected set; }

        protected IdentityUser()
        {
        }

        public IdentityUser(
            Guid id,
            [NotNull] string userName,
            [NotNull] string email
          )
            : base(id)
        {
            Check.NotNull(userName, nameof(userName));
            Check.NotNull(email, nameof(email));

            UserName = userName;
            Email = email;
            ConcurrencyStamp = Guid.NewGuid().ToString("N");
            IsActive = true;

            Roles = new Collection<IdentityUserRole>();
        }

        public virtual void AddRole(Guid roleId)
        {
            Check.NotNull(roleId, nameof(roleId));

            if (IsInRole(roleId))
            {
                return;
            }

            Roles.Add(new IdentityUserRole(Id, roleId));
        }

        public virtual void RemoveRole(Guid roleId)
        {
            Check.NotNull(roleId, nameof(roleId));

            if (!IsInRole(roleId))
            {
                return;
            }

            Roles.RemoveAll(r => r.RoleId == roleId);
        }
        public virtual bool IsInRole(Guid roleId)
        {
            Check.NotNull(roleId, nameof(roleId));

            return Roles.Any(r => r.RoleId == roleId);
        }

        /// <summary>
        /// Use <see cref="IdentityUserManager.ConfirmEmailAsync"/> for regular email confirmation.
        /// Using this skips the confirmation process and directly sets the <see cref="EmailConfirmed"/>.
        /// </summary>
        public virtual void SetEmailConfirmed(bool confirmed)
        {
            EmailConfirmed = confirmed;
        }
        public virtual void SetEmail(string email, bool confirmed)
        {
            Email = email;
            EmailConfirmed = confirmed;
        }
        public virtual void SetPhoneNumberConfirmed(bool confirmed)
        {
            PhoneNumberConfirmed = confirmed;
        }

        /// <summary>
        /// Normally use <see cref="IdentityUserManager.ChangePhoneNumberAsync"/> to change the phone number
        /// in the application code.
        /// This method is to directly set it with a confirmation information.
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="confirmed"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void SetPhoneNumber(string phoneNumber, bool confirmed)
        {
            PhoneNumber = phoneNumber;
            PhoneNumberConfirmed = !phoneNumber.IsNullOrWhiteSpace() && confirmed;
        }

        public virtual void SetIsActive(bool isActive)
        {
            IsActive = isActive;
        }

        public virtual void SetShouldChangePasswordOnNextLogin(bool shouldChangePasswordOnNextLogin)
        {
            ShouldChangePasswordOnNextLogin = shouldChangePasswordOnNextLogin;
        }

        public virtual void SetLastPasswordChangeTime(DateTimeOffset? lastPasswordChangeTime)
        {
            LastPasswordChangeTime = lastPasswordChangeTime;
        }
        public void SetPasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetLockoutEnabled(bool lockoutEnabled)
        {
            LockoutEnabled = lockoutEnabled;
        }
    }
}
