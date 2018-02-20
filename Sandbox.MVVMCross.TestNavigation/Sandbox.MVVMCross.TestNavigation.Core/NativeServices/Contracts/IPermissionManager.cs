using System;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace Sandbox.MVVMCross.TestNavigation.Core.NativeServices.Contracts
{
    public interface IPermissionManager
    {
        Task<PermissionStatus> CheckPermissionStatus(Permission permissionType);

        Task<PermissionStatus> RequestPermission(Permission permissionType);

        Task<PermissionStatus> RequestPermissionNotification();
    }
}
