using Domain.Enum;

namespace Domain.Entities;
public class RoomType
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public Property Property { get; set; } = null!;
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public Currency Currency { get; set; }
    public int MinPersonCount { get; set; }
    public int MaxPersonCount { get; set; }
    public RoomServicie Servicies { get; set; }
    public Amenity Amenities { get; set; }
    public List<Reservation> Reservations { get; } = new List<Reservation>();

    public bool IsDeleted {  get; private set; } = false;

    public RoomType(
        int propertyId,
        string name,
        decimal price,
        Currency currency,
        int minPersonCount,
        int maxPersonCount,
        RoomServicie roomServicie,
        Amenity amenity )
    {
        PropertyId = propertyId;
        SetName( name );
        SetServicies( roomServicie );
        Currency = currency;
        SetCapacity(minPersonCount, maxPersonCount);
        SetServicies(Servicies);
        SetAmenities( amenity );
    }

    protected RoomType()
    {
        
    }
    public void SetName( string name )
    {
        if ( string.IsNullOrWhiteSpace(name) )
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

    public void SetServicies( RoomServicie servicie )
    {
        Servicies = servicie;
    }

    public void SetAmenities( Amenity amenity )
    {
        Amenities = amenity;
    }

    public void Delete()
    {
        IsDeleted = true;
    }
}
