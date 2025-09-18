namespace Application.DTO;
public class SearchRequesDTO
{
    public string? Country { get; set; }
    public string? City { get; set; }
    public DateOnly? ArrivalDate { get; set; }
    public DateOnly? DepartureDate { get; set; }
    public int? Guests { get; set; }
}
