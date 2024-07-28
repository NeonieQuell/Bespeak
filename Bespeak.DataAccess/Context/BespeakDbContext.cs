using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Entities = Bespeak.Entity.Entities;
using Enums = Bespeak.Constants.Enums.RoomStatus;

namespace Bespeak.DataAccess.Context
{
    public class BespeakDbContext : DbContext
    {
        public DbSet<Entities.RoomType> RoomType { get; set; }

        public DbSet<Entities.RoomStatus> RoomStatus { get; set; }

        public DbSet<Entities.Room> Room { get; set; }

        public DbSet<Entities.Reservation> Reservation { get; set; }

        public BespeakDbContext(DbContextOptions<BespeakDbContext> options) : base(options)
        {

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("VARCHAR");
            configurationBuilder.Conventions.Remove(typeof(ForeignKeyIndexConvention));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.RoomType>(rt =>
            {
                rt.HasKey(rt => rt.RoomTypeId).IsClustered(false);

                rt.Property(rt => rt.Name).HasMaxLength(32);
                rt.Property(rt => rt.Description).HasMaxLength(512);

                rt.HasMany(rt => rt.Rooms).WithOne(r => r.RoomType).HasForeignKey(r => r.RoomTypeId);
            });

            // Add default records to the table
            modelBuilder.Entity<Entities.RoomStatus>(rs =>
            {
                rs.HasKey(rs => rs.RoomStatusId).IsClustered();

                rs.Property(rs => rs.Name).HasMaxLength(32);

                rs.HasMany(rs => rs.Rooms).WithOne(r => r.RoomStatus).HasForeignKey(r => r.RoomStatusId);

                rs.HasData(
                    new Entities.RoomStatus { RoomStatusId = (int)Enums.Available, Name = nameof(Enums.Available) },
                    new Entities.RoomStatus { RoomStatusId = (int)Enums.Occupied, Name = nameof(Enums.Occupied) }
                );
            });

            modelBuilder.Entity<Entities.Room>(r =>
            {
                r.HasKey(r => r.RoomId).IsClustered(false);

                r.HasMany(room => room.Reservations)
                    .WithOne(reservation => reservation.Room)
                    .HasForeignKey(reservation => reservation.RoomId);
            });

            modelBuilder.Entity<Entities.Reservation>(r =>
            {
                r.HasKey(r => r.ReservationId).IsClustered();
                r.Property(r => r.Reserver).HasMaxLength(128);
            });
        }
    }
}
