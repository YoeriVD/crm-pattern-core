namespace crm_pattern.core
{
    public class YouthHostel : Entity
        , IEntityMetaData
    {
        public string Name { get; set; }
        public AddressValue Address { get; set; }

        IEntityFieldMetaData[] IEntityMetaData.Fields => new IEntityFieldMetaData[]
        {
            new EntityFieldMetaData<YouthHostel>(z => z.Name),
            new EntityFieldMetaData<YouthHostel>(z => z.Address)
        };
    }
}