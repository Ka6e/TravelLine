using CarFactory.Models.Transmissions;

namespace CarFactory.Factories.TransmissionFactory
{
    public class TransmissionFactory : ITransmissionFactory
    {
        public ITransmission Create( Transmissions transmission )
        {
            return transmission switch
            {
                Transmissions.ManualTransmission => new ManualTransmission(),
                Transmissions.AutomaticTransmission => new AutomaticTransmission(),
                Transmissions.DualClutchTransmission => new DualClutchTransmission(),
                Transmissions.CVTTransmission => new CVTTransmission(),
                Transmissions.RoboticTransmission => new RoboticTransmission(),
                _ => throw new ArgumentException( "Inivalid transmission.", nameof( transmission ) ),
            };
        }
    }
}
