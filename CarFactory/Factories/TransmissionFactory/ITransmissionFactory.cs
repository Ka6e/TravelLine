using CarFactory.Models.Transmissions;

namespace CarFactory.Factories.TransmissionFactory
{
    public interface ITransmissionFactory
    {
        public ITransmission Create( Transmissions transmission );
    }
}
