using server.Data.Entities;
using server.ViewModel.Catalog.Level;
using server.ViewModel.Catalog.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Notifications
{
    public interface INotificationService
    {
        public Task<Notification?> Create(NotificationCreateRequest request);
        public Task<bool> Update(Guid id, NotificationUpdateRequest request);
        public Task<bool> Remove(Guid id);
        public Task<List<Notification>> FindAll();
        public Task<Notification?> FindOne(Guid id);
    }
}
