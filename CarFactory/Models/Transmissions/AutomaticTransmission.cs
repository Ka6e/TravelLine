namespace CarFactory.Models.Transmissions
{
    public class AutomaticTransmission : ITransmission
    {
        public string Name => "Automatic transmission";
        public int NumberOfGears => 8;
    }
}
