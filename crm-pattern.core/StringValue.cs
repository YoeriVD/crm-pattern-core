using Microsoft.EntityFrameworkCore;

namespace crm_pattern.core
{
    [Owned]
    public class StringValue
    {
        public string Value { get; set; }
        public string Label { get; set; }
    }
}