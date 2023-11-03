using JetBrains.Annotations;
using Sample.Novel.PermissionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;

namespace Sample.Novel.PermissionManagement
{
    public interface IPermissionDefinitionSerializer
    {
        Task<(PermissionGroupDefinitionRecord[], PermissionDefinitionRecord[])>
        SerializeAsync(IEnumerable<PermissionGroupDefinition> permissionGroups);

        Task<PermissionGroupDefinitionRecord> SerializeAsync(
            PermissionGroupDefinition permissionGroup);

        Task<PermissionDefinitionRecord> SerializeAsync(
            PermissionDefinition permission,
            [CanBeNull] PermissionGroupDefinition permissionGroup);
    }
}
