using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Sample.Novel.PermissionManagement
{
    public interface IPermissionManagementProvider : ISingletonDependency //TODO: Consider to remove this pre-assumption
    {
        string Name { get; }

        Task<PermissionValueProviderGrantInfo> CheckAsync(
            [NotNull] string name,
            [NotNull] string providerName,
            [NotNull] string providerKey
        );

        Task<MultiplePermissionValueProviderGrantInfo> CheckAsync(
            [NotNull] string[] names,
            [NotNull] string providerName,
            [NotNull] string providerKey
        );

        Task SetAsync(
            [NotNull] string name,
            [NotNull] string providerKey,
            bool isGranted
        );
    }
}
