namespace Domain.Entities;
public class RoomService
{
    public int RoomTypeId { get; set; }
    public RoomType RoomType { get; set; }
    public int ServiceId { get; set; }
    public Service Service { get; set; }
    public bool IsActive { get; set; }
}
