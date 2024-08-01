using Bespeak.ExtensionMethod.ExtensionMethods;
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
                rt.HasMany(rt => rt.Rooms).WithOne(r => r.RoomType).HasForeignKey(r => r.RoomTypeId);

                rt.Property(rt => rt.Name).HasMaxLength(32);
                rt.Property(rt => rt.Description).HasMaxLength(512);

                rt.HasData(
                    new Entities.RoomType
                    {
                        RoomTypeId = Guid.NewGuid(),
                        Name = "Boardroom",
                        Description = @"The boardroom layout features a large central table with chairs surrounding it.
                                        Participants face each other, which lends itself well to direct communication 
                                        and encourages interaction.".MultilinePreserveContent().Trim()
                    },
                    new Entities.RoomType
                    {
                        RoomTypeId = Guid.NewGuid(),
                        Name = "U-shape",
                        Description = @"In this layout, tables are arranged in the shape of the letter ""U"" with 
                                        chairs placed around the outer edges. Presenters or facilitators can move 
                                        freely within the U-shape and engage with participants more directly."
                                        .MultilinePreserveContent().Trim()
                    },
                    new Entities.RoomType
                    {
                        RoomTypeId = Guid.NewGuid(),
                        Name = "Classroom",
                        Description = @"The classroom layout consists of rows of tables and chairs facing a visual 
                                        focal point, such as a screen or whiteboard.".MultilinePreserveContent().Trim()
                    },
                    new Entities.RoomType
                    {
                        RoomTypeId = Guid.NewGuid(),
                        Name = "Auditorium",
                        Description = @"This layout is similar to the classroom style, but without tables. 
                                        Chairs are arranged in rows facing a stage, screen, or presenter. 
                                        The theater layout maximizes seating capacity.".MultilinePreserveContent().Trim()
                    },
                    new Entities.RoomType
                    {
                        RoomTypeId = Guid.NewGuid(),
                        Name = "Crescent",
                        Description = @"In this layout, round tables are partially surrounded by chairs, with one 
                                        side of the table left open. This arrangement encourages interaction among 
                                        smaller groups of attendees and provides clear sightlines to the presenter
                                        or focal point.".MultilinePreserveContent().Trim()
                    },
                    new Entities.RoomType
                    {
                        RoomTypeId = Guid.NewGuid(),
                        Name = "Banquet",
                        Description = @"This layout consists of several round tables with seats all around them, 
                                        allowing smaller groups to sit facing one another as part of a larger whole."
                                        .MultilinePreserveContent().Trim()
                    },
                        new Entities.RoomType
                        {
                            RoomTypeId = Guid.NewGuid(),
                            Name = "Huddle",
                            Description = @"This casual layout consists of a combination of side tables and 
                                            comfortable seating options, such as sofas, armchairs, and bean bags, 
                                            arranged in a relaxed manner.".MultilinePreserveContent().Trim()
                        });
            });

            // Add default records to the table
            modelBuilder.Entity<Entities.RoomStatus>(rs =>
            {
                rs.HasKey(rs => rs.RoomStatusId);
                rs.HasMany(rs => rs.Rooms).WithOne(r => r.RoomStatus).HasForeignKey(r => r.RoomStatusId);

                rs.Property(rs => rs.Name).HasMaxLength(32);

                rs.HasData(
                    new Entities.RoomStatus { RoomStatusId = (int)Enums.Available, Name = nameof(Enums.Available) },
                    new Entities.RoomStatus { RoomStatusId = (int)Enums.Occupied, Name = nameof(Enums.Occupied) }
                );
            });

            modelBuilder.Entity<Entities.Room>(r =>
            {
                r.HasKey(r => r.RoomId);
                r.HasMany(room => room.Reservations)
                    .WithOne(reservation => reservation.Room)
                    .HasForeignKey(reservation => reservation.RoomId);
            });

            modelBuilder.Entity<Entities.Reservation>(r =>
            {
                r.HasKey(r => r.ReservationId);
                r.Property(r => r.Reserver).HasMaxLength(128);
                r.Property(r => r.ReasonForArchiving).HasMaxLength(512);
            });
        }
    }
}
