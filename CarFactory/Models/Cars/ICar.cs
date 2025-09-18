using CarFactory.Models.BodyType;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.Transmissions;

namespace CarFactory.Models.Cars
{
    public interface ICar
    {
        public string Number { get; }
        public IEngine Engine { get; }
        public ITransmission Transmission { get; }
        public Color Color { get; }
        public IBody BodyType { get; }
        public int MaxSpeed();
    }
}
