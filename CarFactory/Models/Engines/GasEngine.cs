using CarFactory.Models.Engines.FuelType;

namespace CarFactory.Models.Engines
{
    public class GasEngine : IEngine
    {
        public string Name => "Gas Engine";

        public FuelKind FuelType => FuelKind.Gas;

        public int HorsePower => 120;

        public double Volume => 1.8;
    }
}
