using System;

namespace crm_pattern.core
{
    internal class EntityFieldMetaData : IEntityFieldMetaData
    {
        public string Name { get; set; }
        public Type Type { get; set; }
    }
}