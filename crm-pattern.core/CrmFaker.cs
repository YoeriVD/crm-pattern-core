using Bogus;

namespace crm_pattern.core
{
    public static class CrmFaker
    {
        public static Faker<AddressValue> Address { get; } =
            new Faker<AddressValue>()
                .RuleFor(a => a.Street, f => f.Address.StreetName())
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.Number, f => f.Address.BuildingNumber());

        public static Faker<ContactPerson> ContactPerson { get; } = new Faker<ContactPerson>()
            .RuleFor(p => p.Id, f => f.Random.Number(min:1))
            .RuleFor(p => p.Address, f => Address.Generate());

        public static Faker<YouthHostel> YouthHostel { get; } = new Faker<YouthHostel>()
            .RuleFor(y => y.Address, f => Address.Generate())
            .RuleFor(y => y.Name, f => new StringValue
            {
                Label = "Naam jeugdhuis", Value = f.Company.CompanyName()
            })
            .RuleFor(y => y.Id, f => f.Random.Number(min:1));
    }
}