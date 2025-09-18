using CarFactory.Builder;
using CarFactory.Extensions;
using CarFactory.Factories.BodyTypeFactory;
using CarFactory.Factories.EngineFactory;
using CarFactory.Factories.TransmissionFactory;
using CarFactory.Models.Cars;

namespace CarFactory.CarManager
{
    public class CarManager
    {
        private readonly EngineFactory _engineFactory = new();
        private readonly TransmissionFactory _transmissionFactory = new();
        private readonly BodyTypeFactory _bodyTypeFactory = new();
        private List<Car> _cars = new List<Car>();

        public void CreateaCar( CarDTO carDTO )
        {
            var builder = new CarBuilder();
            var car = builder.SetName( carDTO.Name )
                .SetColor( carDTO.Color )
                .SetBodyType( _bodyTypeFactory.Create( carDTO.Body ) )
                .SetEngine( _engineFactory.Create( carDTO.Engine ) )
                .SetTransmission( _transmissionFactory.Create( carDTO.Transmission ) )
                .Build();
            _cars.Add( car );
        }

        public List<Car> GetCars()
        {
            return _cars;
        }
    }
}
