using Application.DTO;
using Application.Interface;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Servicies;
public class SearchService : ISearchService
{

    private readonly BookingManagerDbContext _dbContext;

    public SearchService( BookingManagerDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public async Task<List<SearchResponseDTO>> Search( SearchRequesDTO searchRequesDTO )
    {

        if ( searchRequesDTO.DepartureDate < searchRequesDTO.ArrivalDate )
        {
            throw new ArgumentException( "Departure date cannot be earlier than arrival date" );
        }

        IQueryable<Property> query = _dbContext.Properties
            .Include( p => p.RoomTypes )
            .AsNoTracking();

        if ( !string.IsNullOrWhiteSpace( searchRequesDTO.Country ) )
        {
            query = query.Where( x => x.Country == searchRequesDTO.Country );
        }
        if ( !string.IsNullOrWhiteSpace( searchRequesDTO.City ) )
        {
            query = query.Where( x => x.City == searchRequesDTO.City );
        }
        if ( searchRequesDTO.ArrivalDate != null && searchRequesDTO.DepartureDate != null )
        {
            query = query.Where( p => p.RoomTypes.Any( r => !r.Reservations.Any( res =>
            res.IsCanceled == false && res.ArrivalDate < searchRequesDTO.DepartureDate && res.DepartureDate > searchRequesDTO.ArrivalDate ) ) );
        }
        if ( searchRequesDTO.Guests != null && searchRequesDTO.Guests != 0 )
        {
            query = query.Where( p => p.RoomTypes.Any( r =>
            ( r.MaxPersonCount - r.Reservations.Where( res =>
            !res.IsCanceled && res.ArrivalDate < searchRequesDTO.DepartureDate && res.DepartureDate > searchRequesDTO.ArrivalDate )
            .Count() >= searchRequesDTO.Guests ) ) );
        }

        List<Property> properties = await query.ToListAsync();

        return properties.Select( p => new SearchResponseDTO
        {
            PropertyName = p.Name,
            Country = p.Country,
            City = p.City,
            Address = p.Address,
            Rooms = p.RoomTypes.Select( r => new RoomTypeDTO
            {
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
