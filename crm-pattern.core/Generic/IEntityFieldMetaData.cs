using System;

namespace crm_pattern.core
{
    public interface IEntityFieldMetaData
    {
        string Name { get; }
        Type Type { get; }
    }
}