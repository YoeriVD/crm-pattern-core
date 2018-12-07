using System;

namespace crm_pattern.core
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public string Type => GetType().Name;
    }
}