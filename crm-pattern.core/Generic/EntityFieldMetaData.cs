using System;
using System.Linq.Expressions;
using System.Reflection;

namespace crm_pattern.core
{
    public class EntityFieldMetaData<TEntity> : IEntityFieldMetaData
    {
        public EntityFieldMetaData(Expression<Func<TEntity, object>> expression)
        {
            var propertyInfo = GetPropertyInfo(expression);
            Name = GetPropertyInfo(expression).Name;
            Type = GetPropertyInfo(expression).PropertyType;

            {
                var instance = Expression.Parameter(typeof(Entity), "instance");
                var cast = Expression.Convert(instance, typeof(TEntity));
                var body = Expression.Call(cast, propertyInfo.GetGetMethod());
                GetExpression = Expression.Lambda<Func<Entity, object>>(body, instance);
            }
        }

        public string Name { get; }
        public Type Type { get; }
        public Expression<Func<Entity, object>> GetExpression { get; }

        private PropertyInfo GetPropertyInfo<TSource, TProperty>(Expression<Func<TSource, TProperty>> propertyLambda)
        {
            var type = typeof(TSource);

            if (!(propertyLambda.Body is MemberExpression member))
                throw new ArgumentException($"Expression '{propertyLambda}' refers to a method, not a property.");

            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException($"Expression '{propertyLambda}' refers to a field, not a property.");

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(
                    $"Expression '{propertyLambda}' refers to a property that is not from type {type}.");

            return propInfo;
        }
    }
}