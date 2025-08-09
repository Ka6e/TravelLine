using CarFactory.Factories.EngineFactory;
using CarFactory.Factories.TransmissionFactory;
using CarFactory.Models.BodyType;
using CarFactory.Models.Colors;

namespace CarFactory.Extensions
{
    public record CarDTO( string Name, Color Color, BodyType Body, Engines Engine, Transmissions Transmission );
}
