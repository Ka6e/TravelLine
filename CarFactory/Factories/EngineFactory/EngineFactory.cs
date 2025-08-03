using CarFactory.Models.Engines;

namespace CarFactory.Factories.EngineFactory
{
    public class EngineFactory : IEngineFactory
    {
        public IEngine Create( Engines engine )
        {
            return engine switch
            {
                Engines.PetrolEngine => new PetrolEngine(),
                Engines.DieselEngine => new DieselEngine(),
                Engines.GasEngine => new GasEngine(),
                Engines.ElectricEngine => new ElectricEngine(),
                _ => throw new ArgumentException( "Invalid engine.", nameof( engine ) ),
            };
        }
    }
}
