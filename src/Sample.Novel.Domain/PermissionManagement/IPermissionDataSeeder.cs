using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Novel.PermissionManagement
{
    public interface IPermissionDataSeeder
    {
        Task SeedAsync(
        string providerName,
        string providerKey,
        IEnumerable<string> grantedPermissions
    );
    }
}
