namespace crm_pattern.core
{
    public interface IEntityMetaData
    {
        IEntityFieldMetaData[] Fields { get; }
    }
}