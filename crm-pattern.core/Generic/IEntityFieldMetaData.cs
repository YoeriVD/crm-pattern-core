using System;
using System.Linq.Expressions;

namespace crm_pattern.core
{
    public interface IEntityFieldMetaData
    {
        string Name { get; }
        Type Type { get; }
        Expression<Func<Entity, object>> GetExpression { get; }
    }
}