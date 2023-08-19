using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

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

        // seed data with campsites
        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
            new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
            new Campsite {Id = 2, CampsiteTypeId = 2, Nickname = "Krusty Tavern", ImageUrl="https://d3qvqlc701gzhm.cloudfront.net/full/11f1285fc239044309b6920970fec80c45db4c5fb213cbfeb62b75620fc5a1e1.jpg"},
            new Campsite {Id = 3, CampsiteTypeId = 2, Nickname = "Rover Range", ImageUrl="https://d3qvqlc701gzhm.cloudfront.net/full/666782089d9e91069b0be69e785a02b62238a8198b24ab7303f3aac77c2869c8.jpg"},
            new Campsite {Id = 4, CampsiteTypeId = 3, Nickname = "Lone Star", ImageUrl="https://d3qvqlc701gzhm.cloudfront.net/full/4119c74e0538369a94fdf376f1a703395af76cdfa6450b9617f87a9de0aea781.jpg"},
            new Campsite {Id = 5, CampsiteTypeId = 4, Nickname = "Nature's Clouds", ImageUrl="https://d3qvqlc701gzhm.cloudfront.net/full/f0f139df28a36b25886b472280304d0d2f6346eba5e38ecdc8d0729ed3da8c9f.jpg"},
            new Campsite {Id = 6, CampsiteTypeId = 4, Nickname = "The Treetop", ImageUrl="https://traveloregon.com/wp-content/uploads/2016/10/2016-treecampingopal-johnwaller-12.jpg"}
        });

        //seed data with user profiles
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile {Id = 1, FirstName = "Carter", LastName = "Brown", Email = "db@nss.com" }
        });

        //seed data with reservations
        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
        {
            new Reservation {Id = 1, CampsiteId = 1, UserProfileId = 1, CheckinDate = new DateTime(2021, 1, 2), CheckoutDate = new DateTime(2021, 2, 2)}
        });
    }
}