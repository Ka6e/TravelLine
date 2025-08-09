using CarFactory.Models.Engines.FuelType;

namespace CarFactory.Models.Engines
{
    public interface IEngine
    {
        string Name { get; }
        FuelKind FuelType { get; }
        int HorsePower { get; }
        int MaxRPM { get; }
        double Volume { get; }
    }
}
