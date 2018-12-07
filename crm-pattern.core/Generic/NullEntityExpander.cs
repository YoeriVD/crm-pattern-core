using System.Collections.Generic;

namespace crm_pattern.core
{
    public class NullEntityExpander : IEntityExpander
    {
        public Dictionary<string, object> ExpandFields()
        {
            return new Dictionary<string, object>();
        }
    }
}