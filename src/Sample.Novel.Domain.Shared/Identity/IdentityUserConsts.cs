using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Novel.Domain.Shared.Identity
{
    public static class IdentityUserConsts
    {
        public const int MaxUserNameLength = 20;
        public const int MaxNameLength = 5;
        public const int MaxEmailLength = 50;
        public const int MaxPhoneNumberLength = 11;
        public const int MaxPasswordHashLength  = 256;
    }
}
