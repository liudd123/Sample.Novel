using Microsoft.EntityFrameworkCore;
using Sample.Novel.Domain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Novel.EntityFrameworkCore.Extensions
{
    public static class IdentityEfCoreQueryableExtensions
    {
        public static IQueryable<IdentityUser> IncludeDetails(this IQueryable<IdentityUser> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.Roles);
        }

    }
}
