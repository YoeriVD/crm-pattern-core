using System.Collections.Generic;

namespace crm_pattern.core
{
    public class ContactPerson : Entity,
        IEntityMetaData,
        IEntityExpander
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public AddressValue Address { get; set; }


        Dictionary<string, object> IEntityExpander.ExpandFields()
        {
            return new Dictionary<string, object>
            {
                {nameof(Name), Name},
                {nameof(Surname), Surname},
                {nameof(Address), Address}
            };
        }

        public IEntityFieldMetaData[] Fields => new IEntityFieldMetaData[]
        {
            new EntityFieldMetaData<ContactPerson>(z => z.Name),
            new EntityFieldMetaData<ContactPerson>(z => z.Surname),
            new EntityFieldMetaData<ContactPerson>(z => z.Address)
        };
    }
}