using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace crm_pattern.core
{
    public class ContactPerson : Entity, IEntityMetaData,IEntityExcpander
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public AddressValue Address { get; set; }

        public override IEntityMetaData GetMetaData()
        {
            return this;
        }

        public override IEntityExcpander GetExpander()
        {
            return this;
        }

        IEntityFieldMetaData[] IEntityMetaData.Fields => new IEntityFieldMetaData[]
        {
            new EntityFieldMetaData(){ Name = nameof(Name), Type = typeof(string)},
            new EntityFieldMetaData(){ Name = nameof(Surname), Type = typeof(string)},
            new EntityFieldMetaData(){ Name = nameof(Address), Type = typeof(AddressValue)}
        };

        Dictionary<string, object> IEntityExcpander.ExpandFields()
        {
            return new Dictionary<string, object>()
            {
                {nameof(Name), Name},
                {nameof(Surname), Surname},
                {nameof(Address), Address},
            };
        }
    }
}