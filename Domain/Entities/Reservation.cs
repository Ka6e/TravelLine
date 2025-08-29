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
        //string guestName,
        //string guestPhoneNumber,
        Currency currency )
    {
        PropertyId = propertyId;
        RoomTypeId = roomId;
        GuestId = guest.Id;
        SetDate( arrivalDate, departureDate );
        SetTime( arrivalTime, departuretime );
        Guest = guest;
        //SetGuest( guestName, guestPhoneNumber );
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

    //public void SetGuest( string guest, string guestPhoneNumber )
    //{
    //    if ( string.IsNullOrEmpty( guest ) )
    //    {
    //        throw new ArgumentException( "Guest name cannot be empty." );
    //    }
    //    if ( string.IsNullOrEmpty( guestPhoneNumber ) )
    //    {
    //        throw new ArgumentException( "Guest name cannot be empty." );
    //    }
    //    GuestName = guest;
    //    GuestPhoneNumber = guestPhoneNumber;
    //}

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

        int nights = DepartureDate.Day - ArrivalDate.Day;
        if ( nights <= 0 )
        {
            throw new ArgumentException( "Reservation must be at least 1 night." );
        }

        List<Service> services = roomType.Services;
        decimal servicesPrice = 0;
        if ( services != null )
        {
            foreach ( Service service in services )
            {
                servicesPrice += service.Price;
            }
        }

        Total = roomType.DailyPrice * nights + servicesPrice;
    }
    public void Cancel()
    {
        IsCanceled = true;
    }
}
