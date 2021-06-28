using Demo.Business.Notifications;
using System.Collections.Generic;

namespace Demo.Business.Interfaces
{
    public interface INotifier
	{
		bool HasNotification();
		List<Notification> GetNotifications();
		void Handle(Notification notification);
	}
}