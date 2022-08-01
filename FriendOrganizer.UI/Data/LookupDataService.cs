using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class LookupDataService : IFriendLookupDataService
    {
        private FriendOrganizerDbContextFactory _contextFactory;

        public LookupDataService(FriendOrganizerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<LookupItem>> GetFriendLookupAsync()
        {
            using (FriendOrganizerDbContext ctx = _contextFactory.CreateDbContext())
            {
                return await ctx.Friends.AsNoTracking()
                    .Select(f => new LookupItem { Id = f.Id, DisplayMember = f.FirstName + " " + f.LastName }).ToListAsync();
            }
        }
    }
}
