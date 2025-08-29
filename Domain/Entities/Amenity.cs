namespace Domain.Entities;
public class Amenity
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public bool IsActive { get; private set; } = true;
    public List<RoomType> RoomTypes { get; private set; } = new List<RoomType>();

    public Amenity( string name, bool isActive )
    {
        ValidateString( name );
        SetActive( isActive );
    }

    protected Amenity()
    {

    }

    public void SetActive( bool active )
    {
        IsActive = active;
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
