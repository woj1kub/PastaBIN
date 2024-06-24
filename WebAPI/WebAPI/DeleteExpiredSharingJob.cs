using DAL;
using Microsoft.EntityFrameworkCore;
using Quartz;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class DeleteExpiredSharingJob : IJob
    {
        private readonly PastaBINContext _dbContext;

        public DeleteExpiredSharingJob(PastaBINContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var expiredPasta = await _dbContext.PastaGroupSharing
                    .Where(pgs => pgs.EndSharingDate < DateTime.Now && pgs.EndSharingDate!=null)
                    .ToListAsync();

                _dbContext.PastaGroupSharing.RemoveRange(expiredPasta);
                await _dbContext.SaveChangesAsync();

                Console.WriteLine($"Deleted {expiredPasta.Count} expired PastaGroupSharing records at {DateTime.Now}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting expired PastaGroupSharing records: {ex.Message}");
            }
        }
    }
    public class DeleteExpiredPastaTxt : IJob
    {
        private readonly PastaBINContext _dbContext;

        public DeleteExpiredPastaTxt(PastaBINContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var expiredPasta = await _dbContext.PastaText
                    .Where(pgs => pgs.DeleteDate < DateTime.Now && pgs.DeleteDate != null)
                    .ToListAsync();

                _dbContext.PastaText.RemoveRange(expiredPasta);
                await _dbContext.SaveChangesAsync();

                Console.WriteLine($"Deleted {expiredPasta.Count} expired PastaText records at {DateTime.Now}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting expired PastaText records: {ex.Message}");
            }
        }
    }
    public class DeleteExpiredPastaImg : IJob
    {
        private readonly PastaBINContext _dbContext;

        public DeleteExpiredPastaImg(PastaBINContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var expiredPasta = await _dbContext.PastaImages
                    .Where(pgs => pgs.DeleteDate < DateTime.Now && pgs.DeleteDate != null)
                    .ToListAsync();

                _dbContext.PastaImages.RemoveRange(expiredPasta);
                await _dbContext.SaveChangesAsync();

                Console.WriteLine($"Deleted {expiredPasta.Count} expired PastaImages records at {DateTime.Now}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting expired PastaImages records: {ex.Message}");
            }
        }
    }
    public class DeleteExpiredPastaGroups : IJob
    {
        private readonly PastaBINContext _dbContext;

        public DeleteExpiredPastaGroups(PastaBINContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var expiredPasta = await _dbContext.PastaGroupSharing
                    .Where(pgs => pgs.EndSharingDate < DateTime.Now && pgs.EndSharingDate != null)
                    .ToListAsync();

                _dbContext.PastaGroupSharing.RemoveRange(expiredPasta);
                await _dbContext.SaveChangesAsync();

                Console.WriteLine($"Deleted {expiredPasta.Count} expired PastaGroupSharing records at {DateTime.Now}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting expired PastaGroupSharing records: {ex.Message}");
            }
        }
    }
}