namespace CarFactory.Models.Transmissions
{
    public class RoboticTransmission : ITransmission
    {
        public string Name => "Robotic transmission";
        public int NumberOfGears => 6;
    }
}
