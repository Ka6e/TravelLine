namespace Domain.Entities;
public class Amenity
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public List<RoomAmenities> RoomAmenities { get; private set; } = new List<RoomAmenities>();

    public Amenity( string name )
    {
        ValidateString( name );
    }

    protected Amenity()
    {

    }
    public void ValidateString( string name )
    {
        if ( String.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentNullException( $"{nameof( name )} string must not be null or empty" );
        }
        Name = name;
    }
}
