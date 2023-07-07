using Azure.Core;
using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.TimeFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.TimeFrames
{
    public class TimeFrameService : ITimeFrameService
    {
        LangDbContext _context;
        public TimeFrameService(LangDbContext context)
        {
            _context = context;
        }

        public async Task<TimeFrame?> Create(TimeFrameCreateRequest request)
        {
            TimeFrame frame = new TimeFrame()
            {
                StartingTime = request.StartingTime,
                EndingTime = request.EndingTime,
                Activate = true,
            };
            await _context.TimeFrames.AddAsync(frame);
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                return frame;
            }
            return null;
        }

        public async Task<List<TimeFrame>> FindAll()
        {
            return await _context.TimeFrames.ToListAsync();
        }

        public async Task<TimeFrame?> FindOne(Guid id)
        {
            return await _context.TimeFrames.FindAsync(id);
        }

        public async Task<bool> Remove(Guid id)
        {
            var frame = await _context.TimeFrames.FindAsync(id);
            if(frame != null)
            {
                _context.TimeFrames.Remove(frame);
                var result = await _context.SaveChangesAsync();
                if(result > 0)
                {
                    return true;
                }
            }
            return false;

        }

        public async Task<bool> Update(Guid id, TimeFrameUpdateRequest request)
        {
            var frame = await _context.TimeFrames.FindAsync(id);
            if (frame != null)
            {
                frame.Activate = request.Activate;
                frame.StartingTime = request.StartingTime;
                frame.EndingTime = request.EndingTime;


                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> UpdateAll(List<TimeFrameUpdateRequest> requests)
        {
            try
            {
                foreach(var request in requests)
                {
                    var frame = await _context.TimeFrames.FindAsync(request.IdTimeFrame);
                    if (frame != null)
                    {
                        frame.Activate = request.Activate;
                        frame.StartingTime = request.StartingTime;
                        frame.EndingTime = request.EndingTime;
                    }
                }
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }

                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
