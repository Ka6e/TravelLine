namespace CarFactory.Models.Transmissions
{
    public class ManualTransmission : ITransmission
    {
        public int NumberOfGears => 6;

        public string Type => "Manual";
    }
}
