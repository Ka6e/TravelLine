using CarFactory.Models.Engines;

namespace CarFactory.Factories.EngineFactory
{
    public interface IEngineFactory
    {
        public IEngine Create( Engines engine );
    }
}
