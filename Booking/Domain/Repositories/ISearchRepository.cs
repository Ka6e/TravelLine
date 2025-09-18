using Domain.Entities;

namespace Domain.Repositories;
public interface ISearchRepository
{
    Task<List<Property>> Search(
        string? country,
        string? city,
        DateOnly? arrivalDate,
        DateOnly? departureDate,
        int? guests);
}
