using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.Transmissions;

namespace CarFactory.Models.Cars
{
    public interface ICar
    {
        public IEngine Engine { get; }
        public ITransmission Transmission { get; }
        public Color Color { get; }
        public BodyType.BodyType bodyType { get; }
        public int MaxSpeed { get; }
        public int MaxGear { get; }
    }
}
