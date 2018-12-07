using Bogus;

namespace crm_pattern.core
{
    public static class CrmFaker
    {
        private static int ContactId = 0;
        private static int YouthHostelId = 0;
        
        public static Faker<AddressValue> Address { get; } =
            new Faker<AddressValue>()
                .RuleFor(a => a.Street, f => f.Address.StreetName())
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.Number, f => f.Address.BuildingNumber());

        public static Faker<ContactPerson> ContactPerson { get; } = new Faker<ContactPerson>()
            .RuleFor(p => p.Id, f => ++ContactId)
            .RuleFor(p => p.Name, f => f.Person.FirstName)
            .RuleFor(p => p.Surname, f => f.Person.LastName);

        public static Faker<YouthHostel> YouthHostel { get; } = new Faker<YouthHostel>()
            .RuleFor(y => y.Name, f => f.Company.CompanyName())
            .RuleFor(y => y.Id, f => ++YouthHostelId);
    }
}