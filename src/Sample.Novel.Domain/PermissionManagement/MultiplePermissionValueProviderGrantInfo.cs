using Sample.Novel.PermissionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Sample.Novel.PermissionManagement
{
    public class MultiplePermissionValueProviderGrantInfo
    {
        public Dictionary<string, PermissionValueProviderGrantInfo> Result { get; }

        public MultiplePermissionValueProviderGrantInfo()
        {
            Result = new Dictionary<string, PermissionValueProviderGrantInfo>();
        }

        public MultiplePermissionValueProviderGrantInfo(string[] names)
        {
            Check.NotNull(names, nameof(names));

            Result = new Dictionary<string, PermissionValueProviderGrantInfo>();

            foreach (var name in names)
            {
                Result.Add(name, PermissionValueProviderGrantInfo.NonGranted);
            }
        }
    }
}
