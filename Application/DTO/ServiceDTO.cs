using Domain.Enums;

namespace Application.DTO;
public class ServiceDTO
{
    public string Name { get; set; }
    public Currency Currency { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
}
