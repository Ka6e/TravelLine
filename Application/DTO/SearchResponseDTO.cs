namespace Application.DTO;
public class SearchResponseDTO
{
    public string PropertyName { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public List<RoomDTO> Rooms { get; set; }
}
