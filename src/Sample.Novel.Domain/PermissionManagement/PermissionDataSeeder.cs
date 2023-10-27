using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace Sample.Novel.PermissionManagement
{
    public class PermissionDataSeeder : IPermissionDataSeeder, ITransientDependency
    {
        protected IPermissionGrantRepository PermissionGrantRepository { get; }
        protected IGuidGenerator GuidGenerator { get; }


        public PermissionDataSeeder(
            IPermissionGrantRepository permissionGrantRepository,
            IGuidGenerator guidGenerator)
        {
            PermissionGrantRepository = permissionGrantRepository;
            GuidGenerator = guidGenerator;
        }

        public virtual async Task SeedAsync(
            string providerName,
            string providerKey,
            IEnumerable<string> grantedPermissions)
        {
                var names = grantedPermissions.ToArray();
                var existsPermissionGrants = (await PermissionGrantRepository.GetListAsync(names, providerName, providerKey)).Select(x => x.Name).ToList();

                foreach (var permissionName in names.Except(existsPermissionGrants))
                {
                    await PermissionGrantRepository.InsertAsync(
                        new PermissionGrant(
                            GuidGenerator.Create(),
                            permissionName,
                            providerName,
                            providerKey
                        )
                    );
                }
        }
    }
}
