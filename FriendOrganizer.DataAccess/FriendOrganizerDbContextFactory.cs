using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.DataAccess
{
    public class FriendOrganizerDbContextFactory : IDesignTimeDbContextFactory<FriendOrganizerDbContext>
    {
        public FriendOrganizerDbContext CreateDbContext(string[]? args=null)
        {
            var options = new DbContextOptionsBuilder<FriendOrganizerDbContext>();
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FriendOrganizer;Integrated Security=True");

            return new FriendOrganizerDbContext(options.Options);
        }
    }
}
