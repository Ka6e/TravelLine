namespace CarFactory.Models.Transmissions
{
    public class DualClutchTransmission : ITransmission
    {
        public string Name => "Dual clutch transmission";
        public int NumberOfGears => 7;
    }
}
