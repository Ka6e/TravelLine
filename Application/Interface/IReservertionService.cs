using Application.DTO;
using Domain.Entities;

namespace Application.Interface;
public interface IReservertionService
{
    //public Task Search()
    public Task CreateReservation( ReservationDTO reservationDTO );

    public Task<ReservationDTO?> GetById( int id );
    //public Task<List<ReservationDTO>> GetAll( ReservationFilterDTO reservationFilterDTO );
}
