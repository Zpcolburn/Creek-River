using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;
using static System.Net.WebRequestMethods;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }
    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
            new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
            new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
            new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
            new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
        });

        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
            new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
            new Campsite {Id = 2, CampsiteTypeId = 2, Nickname = "Moonlit Meadows", ImageUrl="https://img.freepik.com/premium-photo/moonlit-meadow-escape-camping-scene-photo_960396-20664.jpg"},
            new Campsite {Id = 3, CampsiteTypeId = 3, Nickname = "Hidden Hollow", ImageUrl=""},
            new Campsite {Id = 4, CampsiteTypeId = 4, Nickname = "Timber Ridge", ImageUrl="https://www.fs.usda.gov/Internet/FSE_MEDIA/fseprd923724.jpg"},
            new Campsite {Id = 5, CampsiteTypeId = 5, Nickname = "Sunset Summit", ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT7o0gFDpTWdUf0xpHA1mmdw3qXp5LMQvxAXQ&s"},
            new Campsite {Id = 6, CampsiteTypeId = 6, Nickname = "Forest Glade", ImageUrl="https://img.freepik.com/premium-photo/catwalk-with-simulated-forest-glade-camping-equipment-solid-color-background-4k-ultra-hd_964851-140379.jpg"},
            new Campsite {Id = 7, CampsiteTypeId = 7, Nickname = "Riverbend Refuge", ImageUrl="https://koa.com/content/campgrounds/burney-falls/sectionheaders/05471sectionheaderse8e56bd3-3ab7-49b9-8d14-0f5849c13899.jpg?preset=hero-sm"}
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
           new UserProfile {Id = 1, FirstName = "Zach", LastName = "Colburn", Email = "colburn.ach7@gmail.com"},
        });

        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
        {
            new Reservation {Id = 1, CampsiteId = 1, UserProfileId = 1, CheckinDate = new DateTime(2024, 11, 04), CheckoutDate = new DateTime(2024, 12, 01) },
        });
    }
    
}

