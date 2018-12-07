using System;
using System.Linq.Expressions;
using System.Reflection;

namespace crm_pattern.core
{
    public class EntityFieldMetaData<TEntity> : IEntityFieldMetaData
    {
        public string Name { get; private set; }
        public Type Type { get; private set; }
        public Expression<Func<Entity, object>> GetExpression { get; private set; }

        public EntityFieldMetaData(Expression<Func<TEntity, object>> expression)
        {
            var propertyInfo = GetPropertyInfo(expression);
            Name = GetPropertyInfo(expression).Name;
            Type = GetPropertyInfo(expression).PropertyType;

            {
                ParameterExpression instance = System.Linq.Expressions.Expression.Parameter(typeof(Entity), "instance");
                var cast = System.Linq.Expressions.Expression.Convert(instance, typeof(TEntity));
                var body = System.Linq.Expressions.Expression.Call(cast, propertyInfo.GetGetMethod());
                GetExpression = System.Linq.Expressions.Expression.Lambda<Func<Entity, object>>(body, instance);
            }
            
        }

        private PropertyInfo GetPropertyInfo<TSource, TProperty>(Expression<Func<TSource, TProperty>> propertyLambda)
        {
            Type type = typeof(TSource);

            if (!(propertyLambda.Body is MemberExpression member))
                throw new ArgumentException($"Expression '{propertyLambda}' refers to a method, not a property.");

            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException($"Expression '{propertyLambda}' refers to a field, not a property.");

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException($"Expression '{propertyLambda}' refers to a property that is not from type {type}.");

            return propInfo;
        }
    }
}