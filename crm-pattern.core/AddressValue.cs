using Microsoft.EntityFrameworkCore;

namespace crm_pattern.core
{
    [Owned]
    public class AddressValue
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
    }
}