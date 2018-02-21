using System;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Sandbox.MVVMCross.TestNavigation.Core.NativeServices.Contracts;
using UIKit;

namespace Sandbox_MVVMCross_TestNavigation.iOS.NativeServices
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
            var status = await CheckPermissionStatus(permissionType);

            if (status != PermissionStatus.Granted)
            {
                var result = await CrossPermissions.Current.RequestPermissionsAsync(permissionType);
                status = result[permissionType];
            }

            return status;
        }

        public void RequestPermissionNotification()
        {
            var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);
            UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
        }

        public bool CheckPermissionNotificationStatus()
        {
            //var result = await UserNotifications.UNUserNotificationCenter.Current.GetNotificationSettingsAsync();
            return UIApplication.SharedApplication.CurrentUserNotificationSettings.Types == UIUserNotificationType.None ? false : true;
            //return result.AuthorizationStatus == UserNotifications.UNAuthorizationStatus.Authorized ? true : false;
        }
    }
}
