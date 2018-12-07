using System.Linq;

namespace crm_pattern.core
{
    public class NullEntityMetaData : IEntityMetaData
    {
        public IEntityFieldMetaData[] Fields => Enumerable.Empty<IEntityFieldMetaData>().ToArray();
    }
}