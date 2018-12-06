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
            modelBuilder.Entity<YouthHostel>().HasData(CrmFaker.YouthHostel.Generate(100));
            modelBuilder.Entity<ContactPerson>().HasData(CrmFaker.ContactPerson.Generate(100));
        }
    }
}