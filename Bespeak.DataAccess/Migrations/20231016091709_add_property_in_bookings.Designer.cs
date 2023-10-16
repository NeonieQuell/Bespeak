﻿// <auto-generated />
using System;
using Bespeak.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bespeak.DataAccess.Migrations
{
    [DbContext(typeof(BespeakDbContext))]
    [Migration("20231016091709_add_property_in_bookings")]
    partial class add_property_in_bookings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Bespeak.Entity.Entities.Booking", b =>
                {
                    b.Property<string>("BookingId")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("BookedBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<DateTime>("DateBooked")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoomId")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BookingId");

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Bespeak.Entity.Entities.Room", b =>
                {
                    b.Property<string>("RoomId")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<int>("FloorNumber")
                        .HasColumnType("int");

                    b.Property<string>("RoomTypeId")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("RoomId");

                    b.HasIndex("RoomTypeId")
                        .IsUnique();

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Bespeak.Entity.Entities.RoomType", b =>
                {
                    b.Property<string>("RoomTypeId")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("RoomTypeId");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("Bespeak.Entity.Entities.Booking", b =>
                {
                    b.HasOne("Bespeak.Entity.Entities.Room", "Room")
                        .WithOne()
                        .HasForeignKey("Bespeak.Entity.Entities.Booking", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Bespeak.Entity.Entities.Room", b =>
                {
                    b.HasOne("Bespeak.Entity.Entities.RoomType", "RoomType")
                        .WithOne()
                        .HasForeignKey("Bespeak.Entity.Entities.Room", "RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomType");
                });
#pragma warning restore 612, 618
        }
    }
}