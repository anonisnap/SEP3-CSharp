using System.Collections.Generic;
using Radzen;

namespace Blazor
{
    public class GlobalNotificationService
    {

        public List<NotificationService> AllNotificationServices { get; set; }
        

        public GlobalNotificationService()
        {
            AllNotificationServices = new List<NotificationService>();
        }

        public void ListenToGlobalNotificationService(NotificationService notificationService)
        {
            AllNotificationServices.Add(notificationService);
        }


        public void BroadCastMessage(NotificationMessage notificationMessage)
        {
            AllNotificationServices.ForEach(service => service.Notify(notificationMessage));
        }
        
        
    }
}