using Application.DTO;
using Application.Extensions;
using Application.Interface;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Servicies;
public class ReservationService : IReservartionService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IPropertyRepository _propertyRepository;
    private readonly IRoomTypeRepository _roomTypeRepository;

    public ReservationService( IReservationRepository repository,
        IPropertyRepository propertyRepository,
        IRoomTypeRepository roomTypeRepository )
    {
        _reservationRepository = repository;
        _propertyRepository = propertyRepository;
        _roomTypeRepository = roomTypeRepository;
    }

    public async Task CreateReservation( ReservationRequestDTO reservationDTO )
    {
        if ( !await IsValidReservation( reservationDTO ) )
        {
            throw new InvalidOperationException( "This room is already booked for the selected dates." );
        }

        Property property = await _propertyRepository.GetById(reservationDTO.PropertyId);
        if ( property == null )
        {
            throw new KeyNotFoundException( "Property doesn't exist." );
        }

        RoomType room = await _roomTypeRepository.GetById( reservationDTO.RoomTypeId );
        if ( room == null )
        {
            throw new KeyNotFoundException( "Room doesn't exist" );
        }

        Reservation reservation = reservationDTO.ConvertToEntity();
        reservation.CalculateTotal( room );
        _reservationRepository.Create( reservation );
    }
    public async Task<ReservationResponseDTO?> GetById( int id )
    {
        Reservation reservation = await _reservationRepository.GetById( id );
        return reservation == null ? null : reservation.ConvertToResponseDto();
    }

    public async Task<List<ReservationResponseDTO>> GetAll( ReservationFilterDTO reservationFilter )
    {
        List<Reservation> reservation = await _reservationRepository.GetFiltredReservations(
            reservationFilter.ArrivalDate,
            reservationFilter.DepartureDate,
            reservationFilter.ArrivalTime,
            reservationFilter.DepartureTime,
            reservationFilter.GuestName,
            reservationFilter.Total,
            reservationFilter.Currency
            );

        return reservation == null ? null : reservation.Select( r => r.ConvertToResponseDto() ).ToList();
    }

    private async Task<bool> IsValidReservation( ReservationRequestDTO reservationDTO )
    {
        bool isExistReservaation = await _reservationRepository.ExistReservation(
            reservationDTO.PropertyId,
            reservationDTO.RoomTypeId,
            reservationDTO.ArrivalDate,
            reservationDTO.DepartureDate
            );

        return !isExistReservaation;
    }

    //private IEnumerable<Reservation> FilterList( List<Reservation> reservations, ReservationFilterDTO reservationFilterDTO )
    //{
    //    IEnumerable<Reservation> query = reservations;

    //    if ( reservationFilterDTO.ArrivalDate != null && reservationFilterDTO.DepartureDate != null )
    //    {
    //        query = query.Where( r => r.ArrivalDate == reservationFilterDTO.ArrivalDate
    //         && r.DepartureDate == reservationFilterDTO.DepartureDate );
    //    }
    //    if ( reservationFilterDTO.ArrivalTime != null && reservationFilterDTO.DepartureTime != null )
    //    {
    //        query = query.Where( r => r.ArrivalTime == reservationFilterDTO.ArrivalTime
    //        && r.DepartureTime == reservationFilterDTO.DepartureTime );
    //    }
    //    if ( !string.IsNullOrWhiteSpace( reservationFilterDTO.GuestName ) )
    //    {
    //        query = query.Where( r => r.GuestName == reservationFilterDTO.GuestName );
    //    }
    //    if ( reservationFilterDTO.Total != null && reservationFilterDTO.Total != 0 )
    //    {
    //        query = query.Where( r => r.Total == reservationFilterDTO.Total );
    //    }
    //    if ( reservationFilterDTO.Currency != null )
    //    {
    //        query = query.Where( r => r.Currency == reservationFilterDTO.Currency );
    //    }

    //    return query;
    //}
}
