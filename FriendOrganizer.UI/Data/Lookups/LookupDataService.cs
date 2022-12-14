using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data.Lookups
{
    public class LookupDataService : IFriendLookupDataService, IProgrammingLanguageLookupDataService
    {
        private readonly FriendOrganizerDbContext _context;

        public LookupDataService(FriendOrganizerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LookupItem>> GetFriendLookupAsync()
        {
            return await _context.Friends
                .Select(f => new LookupItem { Id = f.Id, DisplayMember = f.FirstName + " " + f.LastName }).ToListAsync();
        }

        public async Task<IEnumerable<LookupItem>> GetProgrammingLanguageLookupAsync()
        {
            return await _context.ProgrammingLanguages
                .Select(f => new LookupItem { Id = f.Id, DisplayMember = f.Name }).ToListAsync();
        }
    }
}
