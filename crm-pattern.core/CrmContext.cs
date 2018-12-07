using System;
using System.Linq;
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
                    var address = CrmFaker.Address.Generate();
                    y.OwnsOne(e => e.Address).HasData(new
                    {
                        YouthHostelId = youthHostel.Id,
                        address.Street, address.City, address.Number
                    });
                }
            });
            modelBuilder.Entity<ContactPerson>(c =>
            {
                foreach (var contactPerson in CrmFaker.ContactPerson.Generate(100))
                {
                    c.HasData(contactPerson);
                    var address = CrmFaker.Address.Generate();
                    c.OwnsOne(e => e.Address).HasData(new
                    {
                        ContactPersonId = contactPerson.Id,
                        address.Street,
                        address.City,
                        address.Number
                    });
                }
            });
        }
    }

    public static class CrmContextExtensions
    {
        public static IQueryable<Entity> Set (this DbContext context, Type t)
        {
            return (IQueryable<Entity>)context.GetType().GetMethod("Set").MakeGenericMethod(t).Invoke(context, null);
        }
    }
}