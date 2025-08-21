using Application.DTO;
using Application.Interface;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure;

namespace Application.Servicies;
public class ReservationService : IReservertionService
{
    private readonly IReservationRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ReservationService( IReservationRepository repository, IUnitOfWork unitOfWork )
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateReservation( ReservationDTO reservationDTO )
    {
        if ( !await IsValidReservation( reservationDTO ) )
        {
            throw new InvalidOperationException( "This room is already booked for the selected dates." );
        }
        Reservation reservation = Mapper.Mapper.ToReservation( reservationDTO );
        _repository.Create( reservation );
        await _unitOfWork.CommitAsync();
    }
    public async Task<ReservationDTO?> GetById( int id )
    {
        Reservation reservation = await _repository.GetById( id );
        return reservation == null ? null : Mapper.Mapper.ToResevationDTO( reservation );
    }

    public async Task<List<ReservationDTO>> GetAll( ReservationFilterDTO reservationFilter )
    {
        List<Reservation> reservation = await _repository.GetAll();
        var query = FilterList( reservation, reservationFilter );
        return query == null ? null : query.Select(r => Mapper.Mapper.ToResevationDTO(r)).ToList();
    }

    private async Task<bool> IsValidReservation( ReservationDTO reservationDTO )
    {
        List<Reservation> reservations = await _repository.GetAll();

        int reservetionCount = reservations.Where( r =>
            r.PropertyId == reservationDTO.PropertyId
           && r.RoomTypeId == reservationDTO.RoomTypeId
           && r.IsCanceled == false
           && r.ArrivalDate < reservationDTO.DepartureDate
           && r.DepartureDate > reservationDTO.ArrivalDate )
            .Count();

        return reservetionCount == 0;
    }

    private IEnumerable<Reservation> FilterList( List<Reservation> reservations, ReservationFilterDTO reservationFilterDTO )
    {
        IEnumerable<Reservation> query = reservations;

        if ( reservationFilterDTO.ArrivalDate != null && reservationFilterDTO.DepartureDate != null )
        {
            query.Where( r => r.ArrivalDate == reservationFilterDTO.ArrivalDate
            && r.DepartureDate == reservationFilterDTO.DepartureDate );
        }
        if ( reservationFilterDTO.ArrivalTime != null && reservationFilterDTO.DepartureTime != null )
        {
            query.Where( r => r.ArrivalTime == reservationFilterDTO.ArrivalTime
            && r.DepartureTime == reservationFilterDTO.DepartureTime );
        }
        if ( !string.IsNullOrWhiteSpace( reservationFilterDTO.GuestName ) )
        {
            query.Where( r => r.GuestName == reservationFilterDTO.GuestName );
        }
        if ( reservationFilterDTO.Total != 0 )
        {
            query.Where( r => r.Total == reservationFilterDTO.Total );
        }
        if ( reservationFilterDTO.Currency != null )
        {
            query.Where( r => r.Currency == reservationFilterDTO.Currency );
        }

        return query;
    }
}
