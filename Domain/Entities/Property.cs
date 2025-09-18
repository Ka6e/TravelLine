namespace Domain.Entities;
public class Property
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Country { get; private set; }
    public string City { get; private set; }
    public string Address { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }
    public bool IsDeleted { get; private set; } = false;
    public List<RoomType> RoomTypes { get; } = new List<RoomType>();
    public List<Reservation> Reservations { get; } = new List<Reservation>();

    public Property(
        string name,
        string country,
        string city,
        string address,
        double latitude,
        double longitude)
    {
        SetName( name );
        SetCountry( country );
        SetCity( city );
        SetAddress( address );
        SetCoordinats( latitude, longitude );
    }

    protected Property()
    {

    }
    public void SetName( string name )
    {
        if ( !isValidString( name ) )
        {
            throw new ArgumentException( $"{nameof( name )} cannot be null or whitespace.", nameof( name ) );
        }
        Name = name;
    }

    public void SetCountry( string country )
    {
        if ( !isValidString( country ) )
        {
            throw new ArgumentException( $"{nameof( country )} cannot be null or whitespace.", nameof( country ) );
        }
        Country = country;
    }

    public void SetCity( string city )
    {
        if ( !isValidString( city ) )
        {
            throw new ArgumentException( $"{nameof( city )} cannot be null or whitespace.", nameof( city ) );
        }
        City = city;
    }


    public void SetAddress( string address )
    {
        if ( !isValidString( address ) )
        {
            throw new ArgumentException( $"{nameof( address )} cannot be null or whitespace.", nameof( address ) );
        }
        Address = address;
    }


    public void SetCoordinats( double latitude, double longitude )
    {
        if ( latitude < -90 || latitude > 90 )
        {
            throw new ArgumentOutOfRangeException( nameof( latitude ), "Latitude must be between -90 and 90." );

        }
        if ( longitude < -180 || longitude > 180 )
        {
            throw new ArgumentOutOfRangeException( nameof( longitude ), "Longitude must be between -180 and 180." );
        }
        Latitude = latitude;
        Longitude = longitude;
    }

    public void Delete( )
    {
        IsDeleted = true;
    }

    private bool isValidString( string value )
    {
        return !string.IsNullOrEmpty( value );
    }
}
