using Application.DTO;
using Application.Interface;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Servicies;
public class SearchService : ISearchService
{
    private readonly ISearchRepository _searchRepository;

    public SearchService( ISearchRepository searchRepository )
    {
        _searchRepository = searchRepository;
    }

    public async Task<List<SearchResponseDTO>> Search( SearchRequesDTO searchRequesDTO )
    {
        List<Property> properties = await _searchRepository.Search(
            searchRequesDTO.Country,
            searchRequesDTO.City,
            searchRequesDTO.ArrivalDate,
            searchRequesDTO.DepartureDate,
            searchRequesDTO.Guests );

        return properties.Select( p => new SearchResponseDTO
        {
            PropertyName = p.Name,
            Country = p.Country,
            City = p.City,
            Address = p.Address,
            Rooms = p.RoomTypes.Select( r => new RoomTypeDTO
            {
                PropertyId = r.PropertyId,
                Name = r.Name,
                DailyPrice = r.DailyPrice,
                MaxPersonCount = r.MaxPersonCount,
                MinPersonCount = r.MinPersonCount,
                Currency = r.Currency,
                Servicies = r.Servicies,
                Amenities = r.Amenities,
            } ).ToList(),
        } ).ToList();
    }
}
