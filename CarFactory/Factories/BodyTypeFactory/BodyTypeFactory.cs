using CarFactory.Models.BodyType;

namespace CarFactory.Factories.BodyTypeFactory
{
    public class BodyTypeFactory : IBodyTypeFactory
    {
        public IBody Create( BodyType bodyType )
        {
            return bodyType switch
            {
                BodyType.Sedan => new Sedan(),
                BodyType.Coupe => new Coupe(),
                BodyType.Pickup => new Pickup(),
                BodyType.Cabriolet => new Cabriolet(),
                _ => throw new ArgumentException( $"Invalid Car body {bodyType}" ),
            };
        }
    }
}
