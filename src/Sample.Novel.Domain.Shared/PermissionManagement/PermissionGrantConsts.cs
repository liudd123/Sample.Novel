using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Novel.PermissionManagement
{
    public static class PermissionGrantConsts
    {
        /// <summary>
        /// Default value: 64
        /// </summary>
        public static int MaxProviderNameLength { get; set; } = 64;

        /// <summary>
        /// Default value: 64
        /// </summary>
        public static int MaxProviderKeyLength { get; set; } = 64;
    }
}
