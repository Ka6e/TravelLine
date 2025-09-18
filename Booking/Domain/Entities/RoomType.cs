using Domain.Enums;

namespace Domain.Entities;
public class RoomType
{
    public int Id { get; private set; }
    public int PropertyId { get; private set; }
    public Property Property { get; private set; }
    public string Name { get; private set; }
    public decimal DailyPrice { get; private set; }
    public Currency Currency { get; private set; }
    public int MinPersonCount { get; private set; }
    public int MaxPersonCount { get; private set; }
    public List<RoomService> RoomServices { get; private set; } = new List<RoomService>();
    public List<RoomAmenities> RoomAmenities { get; private set; } = new List<RoomAmenities>();
    public List<Reservation> Reservations { get; } = new List<Reservation>();
    public bool IsDeleted { get; private set; } = false;

    public RoomType(
        int propertyId,
        string name,
        decimal price,
        Currency currency,
        int minPersonCount,
        int maxPersonCount )
    {
        PropertyId = propertyId;
        SetName( name );
        SetDailyPrice( price );
        SetCurency( currency );
        SetCapacity( minPersonCount, maxPersonCount );
    }

    protected RoomType()
    {

    }

    public void SetName( string name )
    {
        if ( string.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentException( "Room cannot be empty." );
        }
        Name = name;
    }

    public void SetDailyPrice( decimal price )
    {
        if ( price < 0 )
        {
            throw new ArgumentException( "Price must me greater than zero." );
        }
        DailyPrice = price;
    }

    public void SetCapacity( int minPersons, int maxPersons )
    {
        if ( minPersons < 0 )
        {
            throw new ArgumentException( "Minimum persons must be greater than zero." );
        }
        if ( maxPersons < minPersons )
        {
            throw new ArgumentException( "Maximum persons must be greater or equal to minimum." );
        }
        MinPersonCount = minPersons;
        MaxPersonCount = maxPersons;
    }

    public void AddServicies( Service service, bool isAtive = true )
    {
        if ( service == null )
        {
            throw new ArgumentNullException( nameof( service ) );
        }

        if ( RoomServices.Any( rs => rs.ServiceId == service.Id ) )
        {
            throw new InvalidOperationException( "Service already added to this room." );
        }

        RoomServices.Add( new RoomService
        {
            RoomType = this,
            RoomTypeId = this.Id,
            Service = service,
            ServiceId = service.Id,
            IsActive = isAtive
        } );
    }

    public void AddAmenity( Amenity amenity, bool isActive = true )
    {
        if ( amenity == null )
        {
            throw new ArgumentNullException( nameof( amenity ) );
        }

        if ( RoomAmenities.Any( ra => ra.AmenityId == amenity.Id ) )
        {
            throw new InvalidOperationException( "Amenirt already added to this room." );
        }

        RoomAmenities.Add( new RoomAmenities
        {
            RoomType = this,
            RoomTypeId = this.Id,
            Amenity = amenity,
            AmenityId = amenity.Id,
            IsActive = isActive
        } );
    }

    public void SetCurency(Currency currency)
    {
        if ( !Enum.IsDefined( typeof( Currency ), currency ) )
        {
            throw new ArgumentException( $"Invalid currency: {currency}" );
        }
        Currency = currency;    
    }
    public void Delete()
    {
        IsDeleted = true;
    }
}
