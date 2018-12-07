using System.Collections.Generic;

namespace crm_pattern.core
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public string Type => GetType().Name;

        public abstract IEntityMetaData GetMetaData();

        public abstract IEntityExcpander GetExpander();
    }

    public interface IEntityExcpander
    {
        Dictionary<string, object> ExpandFields();
    }

    public class NullEntityExpander : IEntityExcpander
    {
        public Dictionary<string, object> ExpandFields()
        {
            return new Dictionary<string, object>();
        }
    }
}