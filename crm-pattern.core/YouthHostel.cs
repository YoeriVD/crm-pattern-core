namespace crm_pattern.core
{
    public class YouthHostel : Entity
    {
        public string Name { get; set; }
        public AddressValue Address { get; set; }
        public override IEntityMetaData GetMetaData()
        {
            return new NullEntityMetaData();
        }

        public override IEntityExcpander GetExpander()
        {
            return new NullEntityExpander();
        }
    }
}