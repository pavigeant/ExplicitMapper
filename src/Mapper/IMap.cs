namespace Mapper
{
    public interface IMap
    {
        void Map(object source, object target);
    }

    public interface IMap<TSource, TTarget> : IMap
    {
        void Map(TSource source, TTarget target);
    }
}