using CarFactory.Models.BodyType;

namespace CarFactory.Factories.BodyTypeFactory
{
    public interface IBodyTypeFactory
    {
        public IBody Create( BodyType bodyType );
    }
}
