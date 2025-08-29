using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal class ReservationRepository : IReservationRepository
{
    private readonly BookingManagerDbContext _dbContext;

    public ReservationRepository( BookingManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create( Reservation reservation )
    {
        _dbContext.Reservations.Add( reservation );
    }

    public void Delete( Reservation reservation )
    {
        reservation.Cancel();
        _dbContext.Reservations.Update( reservation );
    }

    public async Task<Reservation?> GetById( int id )
    {
        return await _dbContext.Reservations.FirstOrDefaultAsync( r => r.Id == id );
    }

    public async Task<bool> ExistReservation( int propertId, int roomTypeId, DateOnly arrivalDate, DateOnly departureDate )
    {
        return await _dbContext.Reservations
            .AsNoTracking()
            .AnyAsync( r =>
            r.PropertyId == propertId
            && r.RoomTypeId == roomTypeId
            && r.IsCanceled == false
            && r.ArrivalDate < departureDate
            && r.DepartureDate > arrivalDate
            && r.Guest != null);
    }

    public async Task<List<Reservation>> GetFiltredReservations(
        DateOnly? arrivalDate,
        DateOnly? departureDate,
        TimeOnly? arrivalTime,
        TimeOnly? departureTime,
        string? guestName,
        decimal? total,
        Currency? currency )
    {
        IQueryable<Reservation> query = _dbContext.Reservations
            .AsNoTracking();

        if ( arrivalDate != null && departureDate != null )
        {
            query = query.Where( r => r.ArrivalDate == arrivalDate
            && r.DepartureDate == departureDate );
        }
        if ( arrivalTime != null && departureTime != null )
        {
            query = query.Where( r => r.ArrivalTime == arrivalTime
            && r.DepartureTime == departureTime );
        }
        if ( !String.IsNullOrWhiteSpace( guestName ) )
        {
            query = query.Where( r => r.Guest.FirstName == guestName );
        }
        if ( total != null && total != 0 )
        {
            query = query.Where( r => r.Total == total );
        }
        if ( currency != null )
        {
            query = query.Where( r => r.Currency == currency );
        }

        return await query.ToListAsync();
    }
}
