using CarFactory.Models.BodyType;
using CarFactory.Models.Cars;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.Transmissions;

namespace CarFactory.Builder
{
    public class CarBuilder : ICarBuilder
    {
        private string _name;
        private IEngine _engine;
        private ITransmission _transmission;
        private Color _color;
        private IBody _bodyType;


        public ICarBuilder SetName( string name )
        {
            _name = name;
            return this;
        }

        public ICarBuilder SetBodyType( IBody bodyType )
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
            var car = new Car( _name, _color, _bodyType, _engine, _transmission );
            return car;
        }
    }
}
