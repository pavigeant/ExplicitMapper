namespace Mapper
{
    public interface IMap
    {
        void Map(object source, object target);

        object Map(object source);
    }

    public interface IMap<TSource, TTarget> : IMap
    {
        void Map(TSource source, TTarget target);

        TTarget Map(TSource source);
    }
}