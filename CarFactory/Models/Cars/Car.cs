using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.Transmissions;

namespace CarFactory.Models.Cars
{
    public class Car : ICar
    {
        private readonly IEngine _engine;
        private readonly ITransmission _transmission;
        private readonly Color _color;
        private readonly BodyType.BodyType _bodyType;
        public Car( IEngine engine, ITransmission transmission, Color color, BodyType.BodyType bodyType )
        {
            _engine = engine;
            _transmission = transmission;
            _color = color;
            _bodyType = bodyType;
        }

        public IEngine Engine => _engine;

        public ITransmission Transmission => _transmission;

        public Color Color => _color;

        public BodyType.BodyType bodyType => _bodyType;

        public int MaxSpeed => 500;

        public int MaxGear => _transmission.NumberOfGears;
    }
}
