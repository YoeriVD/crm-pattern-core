using System.Collections.Generic;

namespace crm_pattern.core
{
    public interface IEntityExpander
    {
        Dictionary<string, object> ExpandFields();
    }
}