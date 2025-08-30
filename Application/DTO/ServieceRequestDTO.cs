using Domain.Enums;

namespace Application.DTO;
public class ServiceRequestDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Currency Currency { get; set; }
    public decimal Price { get; set; }
}