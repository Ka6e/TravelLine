namespace CarFactory.Models.Transmissions
{
    public class ManualTransmission : ITransmission
    {
        public string Name => "Manual transmission";
        public int NumberOfGears => 6;
    }
}
