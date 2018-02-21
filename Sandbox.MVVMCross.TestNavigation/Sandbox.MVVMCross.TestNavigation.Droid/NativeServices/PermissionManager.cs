using System;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Sandbox.MVVMCross.TestNavigation.Core.NativeServices.Contracts;

namespace Sandbox.MVVMCross.TestNavigation.Droid.NativeServices
{
    public class PermissionManager : IPermissionManager
    {
        public PermissionManager()
        {
        }

        public Task<PermissionStatus> CheckPermissionStatus(Permission permissionType)
        {
            return CrossPermissions.Current.CheckPermissionStatusAsync(permissionType);
        }

        public async Task<PermissionStatus> RequestPermission(Permission permissionType)
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(permissionType);

            try
            {
                if (status != PermissionStatus.Granted)
                {
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(permissionType);
                    status = results[permissionType];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }

            return status;
        }

        public Task<PermissionStatus> RequestPermissionNotification()
        {
            throw new NotImplementedException();
        }
    }
}

