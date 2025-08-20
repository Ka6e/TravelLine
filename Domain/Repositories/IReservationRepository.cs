using Domain.Entities;

namespace Domain.Repositories;
public interface IReservationRepository
{
    public void Create( Reservation reservation );
    public Task<List<Reservation>> GetAll();
    public Task<Reservation?> GetById( int id );
    public void Delete( Reservation reservation );
}
