using CarFactory.Models.Engines.FuelType;

namespace CarFactory.Models.Engines
{
    public interface IEngine
    {
        string Name { get; }
        FuelKind FuelType { get; }
        int HorsePower { get; }
        double Volume { get; }
    }
}
