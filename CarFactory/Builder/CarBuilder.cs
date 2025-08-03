using CarFactory.Models.BodyType;
using CarFactory.Models.Cars;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.Transmissions;

namespace CarFactory.Builder
{
    public class CarBuilder : ICarBuilder
    {
        private IEngine _engine;
        private ITransmission _transmission;
        private Color _color;
        private BodyType _bodyType;


        public ICarBuilder SetBodyType( BodyType bodyType )
        {
            _bodyType = bodyType;
            return this;
        }

        public ICarBuilder SetColor( Color color )
        {
            _color = color;
            return this;
        }

        public ICarBuilder SetEngine( IEngine engine )
        {
            _engine = engine;
            return this;
        }

        public ICarBuilder SetTransmission( ITransmission transmission )
        {
            _transmission = transmission;
            return this;
        }

        public Car Build()
        {
            var car = new Car( _engine, _transmission, _color, _bodyType );
            return car;
        }
    }
}
