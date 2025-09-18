using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal class SearchRepository : ISearchRepository
{
    private readonly BookingManagerDbContext _bookingManagerDbContext;

    public SearchRepository( BookingManagerDbContext bookingManagerDbContext )
    {
        _bookingManagerDbContext = bookingManagerDbContext;
    }

    public async Task<List<Property>> Search(
        string? country,
        string? city,
        DateOnly? arrivalDate,
        DateOnly? departureDate,
        int? guests )
    {
        IQueryable<Property> query = _bookingManagerDbContext.Properties
            .Include( p => p.RoomTypes )
            .ThenInclude( r => r.Reservations )
            .AsNoTracking();

        if ( !String.IsNullOrWhiteSpace( country ) )
        {
            query = query.Where( p => p.Country == country );
        }
        if ( !String.IsNullOrWhiteSpace( city ) )
        {
            query = query.Where( p => p.City == city );
        }

        if ( arrivalDate != null && departureDate != null )
        {
            query = query.Where( p => p.RoomTypes.Any( r => !r.Reservations.Any( res =>
            res.IsCanceled == false && res.ArrivalDate < departureDate && res.DepartureDate > arrivalDate ) ) );
        }

        if ( guests != null && guests != 0 )
        {
            query = query.Where( p => p.RoomTypes.Any( r =>
            ( r.MaxPersonCount - r.Reservations.Where( res =>
            !res.IsCanceled && res.ArrivalDate < departureDate && res.DepartureDate > arrivalDate )
            .Count() >= guests ) ) );
        }

        return await query.ToListAsync();
    }
}
