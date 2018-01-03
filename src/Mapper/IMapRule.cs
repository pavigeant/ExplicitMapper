namespace Mapper
{
    public interface IMapRule
    {
        void Apply(object source, object target);
    }
}