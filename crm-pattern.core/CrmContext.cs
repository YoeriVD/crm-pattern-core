using Microsoft.EntityFrameworkCore;

namespace crm_pattern.core
{
    public class CrmContext : DbContext
    {
        protected CrmContext()
        {
        }

        public CrmContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<YouthHostel> YouthHostels { get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<YouthHostel>(y =>
            {
                foreach (var youthHostel in CrmFaker.YouthHostel.Generate(100))
                {
                    y.HasData(youthHostel);
                    y.OwnsOne(e => e.Address).HasData(CrmFaker.Address.Generate());
                }
            });
            modelBuilder.Entity<ContactPerson>(c =>
            {
                foreach (var contactPerson in CrmFaker.ContactPerson.Generate(100))
                {
                    c.HasData(contactPerson);
                    c.OwnsOne(e => e.Address).HasData(CrmFaker.Address.Generate());
                }
            });
        }
    }
}