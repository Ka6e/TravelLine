using Domain.Enums;

namespace Domain.Entities;
public class Reservation
{
    public int Id { get; private set; }
    public int PropertyId { get; private set; }
    public Property Property { get; private set; }
    public int RoomTypeId { get; private set; }
    public RoomType RoomType { get; private set; }
    public DateOnly ArrivalDate { get; private set; }
    public DateOnly DepartureDate { get; private set; }
    public TimeOnly ArrivalTime { get; private set; }
    public TimeOnly DepartureTime { get; private set; }
    public int GuestId { get; private set; }
    public Guest Guest { get; private set; }
    public decimal Total { get; private set; }
    public Currency Currency { get; private set; }
    public bool IsCanceled { get; private set; } = false;

    public Reservation(
        int propertyId,
        int roomId,
        DateOnly arrivalDate,
        DateOnly departureDate,
        TimeOnly arrivalTime,
        TimeOnly departuretime,
        Guest guest,
        Currency currency )
    {
        PropertyId = propertyId;
        RoomTypeId = roomId;
        GuestId = guest.Id;
        SetDate( arrivalDate, departureDate );
        SetTime( arrivalTime, departuretime );
        Guest = guest;
        SetCurrency( currency );
    }

    protected Reservation() { }

    public void SetDate( DateOnly arrivalDate, DateOnly departureDate )
    {
        if ( departureDate < arrivalDate )
        {
            throw new ArgumentException( "Departure day cannot be earlier than arrival." );
        }
        ArrivalDate = arrivalDate;
        DepartureDate = departureDate;
    }

    public void SetTime( TimeOnly arrivalTime, TimeOnly departureTime )
    {
        if ( departureTime < arrivalTime )
        {
            throw new ArgumentException( "Departure time cannot be earlier than arrival." );
        }
        ArrivalTime = arrivalTime;
        DepartureTime = departureTime;
    }

    public void SetCurrency( Currency currency )
    {
        Currency = currency;
    }

    public void CalculateTotal( RoomType roomType )
    {
        if ( roomType == null )
        {
            throw new ArgumentNullException( nameof( roomType ) );
        }

        int nights = (DepartureDate.ToDateTime(TimeOnly.MinValue) - ArrivalDate.ToDateTime(TimeOnly.MinValue)).Days;
        if ( nights <= 0 )
        {
            throw new ArgumentException( "Reservation must be at least 1 night." );
        }

        decimal servicesPrice = 0;
        foreach ( var roomService in roomType.RoomServices )
        {
            if ( roomService.IsActive )
            {
                servicesPrice += roomService.Service.Price;
            }
        }

        Total = roomType.DailyPrice * nights + servicesPrice;
    }
    public void Cancel()
    {
        IsCanceled = true;
    }
}
