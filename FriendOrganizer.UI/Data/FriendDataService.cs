using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private readonly FriendOrganizerDbContextFactory _contextFactory;

        public FriendDataService(FriendOrganizerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<Friend> GetByIdAsync(int friendId)
        {
            using (FriendOrganizerDbContext ctx = _contextFactory.CreateDbContext())
            {
                return await ctx.Friends.AsNoTracking().SingleAsync(f => f.Id == friendId);
            }
        }

        public async Task SaveAsync(Friend friend)
        {
            using (FriendOrganizerDbContext ctx = _contextFactory.CreateDbContext())
            {
                ctx.Friends.Attach(friend);
                ctx.Entry(friend).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
        }
    }
}
