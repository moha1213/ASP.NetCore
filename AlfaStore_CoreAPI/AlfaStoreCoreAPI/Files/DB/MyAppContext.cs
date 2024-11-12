using DataAccessLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace AlfaStoreCoreAPI.Files.DB
{
    public class MyAppContext : DbContext
    {
        private readonly string _connectionString;

        public MyAppContext() : base()
        {
            _connectionString = GetConnectionString();
        }

        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new()
            {
                ["Data Source"] = "DESKTOP-1AGHHQA",
                ["Initial Catalog"] = "AlfaStoreCoreDB",
                ["User ID"] = "MGaber",
                ["Password"] = "admin",
                ["TrustServerCertificate"] = "True"
            };

            return builder.ConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                                      => optionsBuilder.UseSqlServer(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
    .HasMany(e => e.Cities)
    .WithOne(e => e.Country)
    .HasForeignKey(e => e.CountryId)
    .IsRequired(false);

            modelBuilder.Entity<City>()
.HasMany(e => e.Districts)
.WithOne(e => e.City)
.HasForeignKey(e => e.CityId)
.IsRequired(false);

            modelBuilder.Entity<District>()
                .HasMany(e => e.Addresses)
    .WithOne(e => e.District)
    .HasForeignKey(e => e.DistrictId)
    .IsRequired(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Contacts)
    .WithOne(e => e.Address)
    .HasForeignKey(e => e.AddressId)
    .IsRequired(false);

            modelBuilder.Entity<Contact>()
        .HasOne(e => e.Phone)
        .WithOne(e => e.Contact)
        .HasForeignKey<Phone>(e => e.ContactId)
        .IsRequired(false);

            //to ignore case sensitive in search
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        }
        public DbSet<Address> addresses { get; set; }
        public DbSet<District> districts { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Phone> phones { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Branch> branches { get; set; }
        public DbSet<UserProfile> users { get; set; }

        //public DbSet<Asset> assets { get; set; }
        //public DbSet<AssetDeprecation> assetDeprecations { get; set; }
        //public DbSet<AssetDeprecationDetails> assetDeprecationDetails { get; set; }      
        //public DbSet<Customer> customers { get; set; }
        //public DbSet<Item> items { get; set; }
        ////public DbSet<Quantity> quantities { get; set; }
        //public DbSet<Role> roles { get; set; }
        //public DbSet<RoleScreen> roleScreens { get; set; }
        //public DbSet<Screen> screens { get; set; }
        //public DbSet<Supplier> suppliers { get; set; }

        //public DbSet<UserRole> userRoles { get; set; }
        //public DbSet<StoreTransaction> storeTransactions { get; set; }
        //public DbSet<Tax> taxes { get; set; }
        //public DbSet<StoreTransactionDetails> storeTransactionDetails { get; set; }
        //public DbSet<PaymentSchedule> paymentSchedules { get; set; }
        //public DbSet<Payment> payments { get; set; }
        //public DbSet<MType> mTypes { get; set; }
        //public DbSet<SearchModel> searchModels { get; set; }
        //public DbSet<Warehouse> warehouses { get; set; }
        //public DbSet<WarehouseItems> itemWarehouses { get; set; }
        //public DbSet<StoreTransfere> storeTransferes { get; set; }
        //public DbSet<StoreTransfereDetails> StoreTransfereDetails { get; set; }
        //public DbSet<UOM> uOMs { get; set; }
        //public DbSet<ItemSuppliers> itemSuppliers { get; set; }
        //public DbSet<CostCentre> costCentres { get; set; }
        //public DbSet<ScreenDefaults> screenDefaultss { get; set; }
        //public DbSet<UserRoleScreenDefaults> userRoleScreenDefaultss { get; set; }
        //public DbSet<RoleScreenDetails> roleScreenDetailss { get; set; }

    }
}
