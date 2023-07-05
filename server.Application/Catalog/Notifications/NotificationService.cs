using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Notifications
{
    public class NotificationService : INotificationService
    {
        LangDbContext _context;
        public NotificationService(LangDbContext context)
        {
            _context = context;
        }
        public async Task<Notification?> Create(NotificationCreateRequest request)
        {
            Notification notification = new Notification()
            {
                Content = request.Content,
                CreateDate = DateTime.Now,
                IsEmployee = request.IsEmployee,
                Title = request.Title,
            };

            await _context.Notifications.AddAsync(notification);

            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return notification;
            }
            return null;
        }

        public async Task<List<Notification>> FindAll()
        {
            return await _context.Notifications.ToListAsync();
        }

        public async Task<Notification?> FindOne(Guid id)
        {
            return await _context.Notifications.FindAsync(id);
        }

        public async Task<bool> Remove(Guid id)
        {
            var noti = await _context.Notifications.FindAsync(id);
            if (noti != null)
            {
                _context.Notifications.Remove(noti);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Update(Guid id, NotificationUpdateRequest request)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification != null)
            {
                notification.Content = request.Content;
                notification.IsEmployee = request.IsEmployee;
                notification.Title = request.Title;


                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
