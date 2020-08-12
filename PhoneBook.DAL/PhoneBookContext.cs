using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace PhoneBook.DAL
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext() : base("PhoneBookContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhoneBookContext, PhoneBook.DAL.Migrations.Configuration>("PhoneBookContext"));
        }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<People>().Map(map =>
            {
                map.Properties(
                    p => new
                    {
                        p.ID,
                        p.FirstName,
                        p.LastName,
                        p.Email,
                        p.PhoneNumber,
                        p.IsActive



                    });
                map.ToTable("People");
            })
           .Map(map =>
           {
               map.Properties(
                   p => new
                   {
                       p.AddressOne,
                       p.AddressTwo,
                       p.CityId,
                       p.StateId,
                       p.CountryId,
                       p.PinCode
                   });
               map.ToTable("Address");
           });



        }

        public override int SaveChanges()
        {
            var Changed = ChangeTracker.Entries();
            if (Changed != null)
            {
                foreach (var entry in Changed.Where(e => e.State == EntityState.Deleted))
                {
                    entry.State = EntityState.Modified;
                    entry.CurrentValues["IsActive"] = false;
                }


            }
            return base.SaveChanges();
        }


    }
}
