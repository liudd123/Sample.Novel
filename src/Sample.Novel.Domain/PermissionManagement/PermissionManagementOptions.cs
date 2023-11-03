using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Collections;

namespace Sample.Novel.PermissionManagement
{
    public class PermissionManagementOptions
    {
        public ITypeList<IPermissionManagementProvider> ManagementProviders { get; }

        public Dictionary<string, string> ProviderPolicies { get; }

        /// <summary>
        /// Default: true.
        /// </summary>
        public bool SaveStaticPermissionsToDatabase { get; set; } = true;

        /// <summary>
        /// Default: false.
        /// </summary>
        public bool IsDynamicPermissionStoreEnabled { get; set; }

        public PermissionManagementOptions()
        {
            ManagementProviders = new TypeList<IPermissionManagementProvider>();
            ProviderPolicies = new Dictionary<string, string>();
        }
    }
}
