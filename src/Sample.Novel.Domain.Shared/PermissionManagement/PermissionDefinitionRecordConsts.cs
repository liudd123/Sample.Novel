﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Novel.PermissionManagement
{
    public class PermissionDefinitionRecordConsts
    {
        /// <summary>
        /// Default value: 128
        /// </summary>
        public static int MaxNameLength { get; set; } = 128;

        public static int MaxDisplayNameLength { get; set; } = 256;

        public static int MaxProvidersLength { get; set; } = 128;

        public static int MaxStateCheckersLength { get; set; } = 256;
    }
}
