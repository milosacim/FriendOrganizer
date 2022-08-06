using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace FriendOrganizer.DataAccess
{
    public class FriendOrganizerDbContext : DbContext
    {
        public FriendOrganizerDbContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>().HasData(
                new Friend { Id = 1, FirstName = "Thomas", LastName = "Huber" },
                new Friend { Id = 2, FirstName = "Andreas", LastName = "Boehler" },
                new Friend { Id = 3, FirstName = "Julia", LastName = "Huber" },
                new Friend { Id = 4, FirstName = "Chrissi", LastName = "Egin" });

            modelBuilder.Entity<ProgrammingLanguage>().HasData(
                new ProgrammingLanguage { Id = 1, Name = "C#" },
                new ProgrammingLanguage { Id = 2, Name = "TypeScript" },
                new ProgrammingLanguage { Id = 3, Name = "Julia" },
                new ProgrammingLanguage { Id = 4, Name = "F#" },
                new ProgrammingLanguage { Id = 5, Name = "Swift" },
                new ProgrammingLanguage { Id = 6, Name = "Java" }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
