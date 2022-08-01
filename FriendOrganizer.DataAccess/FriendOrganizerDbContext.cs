﻿using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace FriendOrganizer.DataAccess
{
    public class FriendOrganizerDbContext : DbContext
    {
        public FriendOrganizerDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>().HasData(
                new Friend { Id = 1, FirstName = "Thomas", LastName = "Huber"},
                new Friend { Id = 2, FirstName = "Andreas", LastName = "Boehler"},
                new Friend { Id = 3, FirstName = "Julia", LastName = "Huber"},
                new Friend { Id = 4, FirstName = "Chrissi", LastName = "Egin"});
            base.OnModelCreating(modelBuilder);
        }
    }
}