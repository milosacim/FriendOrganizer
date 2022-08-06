﻿// <auto-generated />
using System;
using FriendOrganizer.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FriendOrganizer.DataAccess.Migrations
{
    [DbContext(typeof(FriendOrganizerDbContext))]
    partial class FriendOrganizerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FriendOrganizer.Model.Friend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("FavoriteLanguageId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FavoriteLanguageId");

                    b.ToTable("Friends");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Thomas",
                            LastName = "Huber"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Andreas",
                            LastName = "Boehler"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Julia",
                            LastName = "Huber"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Chrissi",
                            LastName = "Egin"
                        });
                });

            modelBuilder.Entity("FriendOrganizer.Model.ProgrammingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ProgrammingLanguages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 2,
                            Name = "TypeScript"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Julia"
                        },
                        new
                        {
                            Id = 4,
                            Name = "F#"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Swift"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Java"
                        });
                });

            modelBuilder.Entity("FriendOrganizer.Model.Friend", b =>
                {
                    b.HasOne("FriendOrganizer.Model.ProgrammingLanguage", "FavoriteLanguage")
                        .WithMany()
                        .HasForeignKey("FavoriteLanguageId");

                    b.Navigation("FavoriteLanguage");
                });
#pragma warning restore 612, 618
        }
    }
}
