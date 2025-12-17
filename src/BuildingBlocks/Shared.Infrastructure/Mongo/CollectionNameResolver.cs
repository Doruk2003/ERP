namespace Shared.Infrastructure.Mongo;

public static class CollectionNameResolver
{
    public static string Resolve<T>(string moduleName)
    {
        return $"{moduleName}_{typeof(T).Name}";
    }
}
