using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;

namespace FriendOrganizer.DataAccess
{
    public interface IFriendOrganizerDbContext
    {
        DbSet<Friend> Friends { get; set; }
    }
}