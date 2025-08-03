namespace CarFactory.Models.Transmissions
{
    public class AutomaticTransmission : ITransmission
    {
        public int NumberOfGears => 8;

        public string Type => "Automatic";
    }
}
