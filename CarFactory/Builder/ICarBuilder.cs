using System.Xml.Linq;
using CarFactory.Models.BodyType;
using CarFactory.Models.Cars;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.Transmissions;

namespace CarFactory.Builder
{
    public interface ICarBuilder
    {
        ICarBuilder SetName( string name );
        ICarBuilder SetEngine( IEngine engine );
        ICarBuilder SetTransmission( ITransmission transmission );
        ICarBuilder SetColor( Color color );
        ICarBuilder SetBodyType( IBody bodyType );
        Car Build();
    }

}
