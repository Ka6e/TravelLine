namespace CarFactory.Models.Transmissions
{
    public interface ITransmission
    {
        //string Name { get; }
        int NumberOfGears { get; }
        string Type { get; }
    }
}
