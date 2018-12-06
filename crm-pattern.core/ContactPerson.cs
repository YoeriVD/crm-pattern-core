namespace crm_pattern.core
{
    public class ContactPerson : Entity
    {
        public StringValue Name { get; set; }
        public StringValue Surname { get; set; }
        public AddressValue Address { get; set; }
    }
}