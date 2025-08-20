using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class ReservationRepository : IReservationRepository
{
    private readonly BookingManagerDbContext _bookingManagerDbContext;

    public ReservationRepository( BookingManagerDbContext bookingManagerDbContext )
    {
        _bookingManagerDbContext = bookingManagerDbContext;
    }

    public void Create( Reservation reservation )
    {
        _bookingManagerDbContext.Reservations.Add( reservation );
    }

    public void Delete( Reservation reservation )
    {
        reservation.Cancel();
        _bookingManagerDbContext.Reservations.Update( reservation );
    }

    public async Task<List<Reservation>> GetAll()
    {
        return await _bookingManagerDbContext.Reservations.ToListAsync();
    }

    public async Task<Reservation?> GetById( int id )
    {
        return await _bookingManagerDbContext.Reservations.FirstOrDefaultAsync( r => r.Id == id );
    }
}
