using Application.DTO;
using Domain.Entities;

namespace Application.Interface;
public interface IReservartionService
{
    public Task CreateReservation( ReservationDTO reservationDTO );
    public Task<ReservationResponseDTO?> GetById( int id );
    public Task<List<ReservationResponseDTO>> GetAll( ReservationFilterDTO reservationFilterDTO );
}
