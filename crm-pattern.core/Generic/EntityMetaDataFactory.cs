using System;
using System.Linq;
using Bogus.Platform;
using Microsoft.EntityFrameworkCore;

namespace crm_pattern.core
{
    public class EntityMetaDataFactory
    {
        public static IEntityExpander GetExpander(object t)
        {
            if (t is IEntityExpander) return t as IEntityExpander;
            if (t is string)
            {
                t = StringToType(t as string);
                return Activator.CreateInstance(t as Type) as IEntityExpander;
            }
            return new NullEntityExpander();
        }

        public static IEntityMetaData GetMetaData(object t)
        {
            if(t is IEntityFieldMetaData) return t as IEntityMetaData;
            if (t is string)
            {
                t = StringToType(t as string);
                return Activator.CreateInstance(t as Type) as IEntityMetaData;
            }
            return new NullEntityMetaData();
        }

        public static IQueryable<Entity> Set(DbContext context, object t)
        {
            if (t is Entity) return Set(context, t.GetType());
            if (t is string) return Set(context, StringToType(t as string));
            return (IQueryable<Entity>)context.GetType().GetMethod("Set").MakeGenericMethod(t as Type).Invoke(context, null);
        }

        private static Type StringToType(string s)
        {
            var possibleTypes = typeof(ContactPerson).GetAssembly().GetTypes()
                .Where(t => !string.IsNullOrWhiteSpace(t.Name))
                .Where(t => t.IsSubclassOf(typeof(Entity)))
                .ToDictionary(t => t.Name.ToLowerInvariant());
            var lowerType = s.ToLowerInvariant();

            if (!possibleTypes.ContainsKey(lowerType)) throw new ArgumentException(s);
            var type = possibleTypes[lowerType];
            return type;
        }
    }
}