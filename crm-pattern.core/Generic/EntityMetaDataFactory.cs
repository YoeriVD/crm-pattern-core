using System;
using System.Linq;
using Bogus.Platform;
using Microsoft.EntityFrameworkCore;

namespace crm_pattern.core
{
    public static class EntityMetaDataFactory
    {
        public static IEntityExpander GetExpander(object t)
        {
            switch (t)
            {
                case IEntityExpander _:
                    return t as IEntityExpander;
                case string _:
                    t = StringToType(t as string);
                    return Activator.CreateInstance(t as Type) as IEntityExpander;
                default:
                    return new NullEntityExpander();
            }
        }

        public static IEntityMetaData GetMetaData(object t)
        {
            switch (t)
            {
                case IEntityFieldMetaData _:
                    return t as IEntityMetaData;
                case string _:
                    t = StringToType(t as string);
                    return Activator.CreateInstance(t as Type) as IEntityMetaData;
                default:
                    return new NullEntityMetaData();
            }
        }

        public static IQueryable<Entity> Set(DbContext context, object t)
        {
            switch (t)
            {
                case Entity _:
                    return Set(context, t.GetType());
                case string _:
                    return Set(context, StringToType(t as string));
                default:
                    return (IQueryable<Entity>) context.GetType().GetMethod("Set").MakeGenericMethod(t as Type)
                        .Invoke(context, null);
            }
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