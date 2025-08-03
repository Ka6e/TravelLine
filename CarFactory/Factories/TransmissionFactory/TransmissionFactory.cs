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
                _ => throw new ArgumentException( "Inivalid transmission.", nameof( transmission ) ),
            };
        }
    }
}
