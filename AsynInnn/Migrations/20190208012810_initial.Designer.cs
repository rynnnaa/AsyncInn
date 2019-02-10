﻿// <auto-generated />
using AsynInnn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsynInnn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20190208012810_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsynInnn.Models.Amenities", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Dishwasher"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Washer/Dryer"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Kitchen"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Deck"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Pull-Out-Bed"
                        });
                });

            modelBuilder.Entity("AsynInnn.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("ID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "Seattle, WA",
                            Name = "Async North Seattle",
                            Phone = "(206)123-4567"
                        },
                        new
                        {
                            ID = 2,
                            Address = "Seattle, WA",
                            Name = "Async South Seattle",
                            Phone = "(206)123-4567"
                        },
                        new
                        {
                            ID = 3,
                            Address = "Seattle, WA",
                            Name = "Async West Seattle",
                            Phone = "(206)123-4567"
                        },
                        new
                        {
                            ID = 4,
                            Address = "Eastern, WA",
                            Name = "Async Eastern",
                            Phone = "(206)123-4567"
                        },
                        new
                        {
                            ID = 5,
                            Address = "Western, WA",
                            Name = "Async Western",
                            Phone = "(206)123-4567"
                        });
                });

            modelBuilder.Entity("AsynInnn.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelID");

                    b.Property<int>("RoomNumber");

                    b.Property<bool>("PetFriendly");

                    b.Property<decimal>("Rate");

                    b.Property<int>("RoomID");

                    b.HasKey("HotelID", "RoomNumber");

                    b.HasIndex("RoomID");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("AsynInnn.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("RoomLayout");

                    b.HasKey("ID");

                    b.ToTable("Room");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Monarcle",
                            RoomLayout = 0
                        },
                        new
                        {
                            ID = 2,
                            Name = "Sheiseido",
                            RoomLayout = 0
                        },
                        new
                        {
                            ID = 3,
                            Name = "Beveren",
                            RoomLayout = 1
                        },
                        new
                        {
                            ID = 4,
                            Name = "Titan",
                            RoomLayout = 2
                        },
                        new
                        {
                            ID = 5,
                            Name = "Oculum",
                            RoomLayout = 1
                        },
                        new
                        {
                            ID = 6,
                            Name = "Vivica",
                            RoomLayout = 1
                        });
                });

            modelBuilder.Entity("AsynInnn.Models.RoomAmenities", b =>
                {
                    b.Property<int>("AmenitiesID");

                    b.Property<int>("RoomID");

                    b.HasKey("AmenitiesID", "RoomID");

                    b.HasIndex("RoomID");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("AsynInnn.Models.HotelRoom", b =>
                {
                    b.HasOne("AsynInnn.Models.Hotel", "Hotel")
                        .WithMany("HotelRoom")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsynInnn.Models.Room", "Room")
                        .WithMany("HotelRoom")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AsynInnn.Models.RoomAmenities", b =>
                {
                    b.HasOne("AsynInnn.Models.Amenities", "Amenities")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenitiesID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsynInnn.Models.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
