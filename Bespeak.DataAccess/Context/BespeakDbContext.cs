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
            });

            // Add default records to the table
            modelBuilder.Entity<Entities.RoomStatus>(rs =>
            {
                rs.HasKey(rs => rs.RoomStatusId).IsClustered();

                rs.HasData(
                    new Entities.RoomStatus { RoomStatusId = (int)Enums.Available, Name = nameof(Enums.Available) },
                    new Entities.RoomStatus { RoomStatusId = (int)Enums.Occupied, Name = nameof(Enums.Occupied) }
                );
            });

            modelBuilder.Entity<Entities.Room>(r =>
            {
                r.HasKey(r => r.RoomId).IsClustered(false);
                r.HasOne(r => r.RoomType).WithOne().HasForeignKey<Entities.RoomType>(r => r.RoomTypeId);
                r.HasOne(r => r.RoomStatus).WithOne().HasForeignKey<Entities.RoomStatus>(r => r.RoomStatusId);
            });

            modelBuilder.Entity<Entities.Reservation>(r =>
            {
                r.HasKey(r => r.ReservationId).IsClustered();
                r.HasOne(r => r.Room).WithOne().HasForeignKey<Entities.Room>(r => r.RoomId);

                r.Property(r => r.Reserver).HasMaxLength(128);
            });
        }
    }
}
