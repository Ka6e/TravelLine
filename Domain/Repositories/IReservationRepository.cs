using Domain.Entities;
using Domain.Enums;

namespace Domain.Repositories;
public interface IReservationRepository
{
    public void Create( Reservation reservation );
    //public Task<List<Reservation>> GetAll();
    public Task<Reservation?> GetById( int id );
    public void Delete( Reservation reservation );

    public Task<bool> ExistReservation( 
        int propertId, 
        int roomTypeId,
        DateOnly arrivalDate,
        DateOnly departureDate
        );

    public Task<List<Reservation>> GetFiltredReservations(
        DateOnly? arrivalDate,
        DateOnly? departureDate,
        TimeOnly? arrivalTime,
        TimeOnly? departureTime,
        string? guestName,
        decimal? total,
        Currency? currency
        );
}
