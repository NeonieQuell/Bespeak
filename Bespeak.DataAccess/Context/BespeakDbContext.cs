using Bespeak.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Bespeak.DataAccess.Context
{
    public class BespeakDbContext : DbContext
    {
        public DbSet<RoomType> RoomTypes { get; set; } = null!;

        public DbSet<Room> Rooms { get; set; } = null!;

        public DbSet<Booking> Bookings { get; set; } = null!;

        public BespeakDbContext(DbContextOptions<BespeakDbContext> options) : base(options)
        {

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar");
            configurationBuilder.Conventions.Remove(typeof(ForeignKeyIndexConvention));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomType>(rt =>
            {
                rt.HasKey(rt => rt.RoomTypeId);
                rt.HasIndex(rt => rt.RoomTypeId).IsClustered(false);

                rt.Property(rt => rt.RoomTypeId).HasMaxLength(32);
                rt.Property(rt => rt.TypeName).HasMaxLength(32);
                rt.Property(rt => rt.Description).HasMaxLength(512);
            });

            modelBuilder.Entity<Room>(r =>
            {
                r.HasKey(r => r.RoomId);
                r.HasIndex(r => r.RoomId).IsClustered(false);
                r.HasOne(r => r.RoomType).WithOne().HasForeignKey<Room>(r => r.RoomTypeId);

                r.Property(r => r.RoomId).HasMaxLength(32);
                r.Property(r => r.RoomTypeId).HasMaxLength(32);
                r.Property(r => r.Status).HasMaxLength(32);
            });

            modelBuilder.Entity<Booking>(b =>
            {
                b.HasKey(b => b.BookingId);
                b.HasIndex(b => b.BookingId).IsClustered(false);
                b.HasOne(b => b.Room).WithOne().HasForeignKey<Booking>(b => b.RoomId);

                b.Property(b => b.BookingId).HasMaxLength(32);
                b.Property(b => b.RoomId).HasMaxLength(32);
                b.Property(b => b.BookedBy).HasMaxLength(128);
            });
        }
    }
}
