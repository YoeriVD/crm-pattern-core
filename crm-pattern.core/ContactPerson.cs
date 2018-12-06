namespace crm_pattern.core
{
    public class ContactPerson : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public AddressValue Address { get; set; }
    }
}