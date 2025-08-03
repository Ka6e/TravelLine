using CarFactory.Models.BodyType;
using CarFactory.Models.Cars;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.Transmissions;

namespace CarFactory.Builder
{
    public interface ICarBuilder
    {
        ICarBuilder SetEngine( IEngine engine );
        ICarBuilder SetTransmission( ITransmission transmission );
        ICarBuilder SetColor( Color color );
        ICarBuilder SetBodyType( BodyType bodyType );
        Car Build();
    }

}
