namespace Domain.Entities;
public class Amenity
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public bool IsActive { get; private set; } = true;

    public Amenity(string name)
    {
        Name = ValidateString(name);
    }

    protected Amenity()
    {
        
    }

    public void SetActive( bool active )
    {
        IsActive = active;
    }
    public string ValidateString(string name)
    {
        if ( String.IsNullOrWhiteSpace(name) )
        {
            throw new ArgumentNullException( $"{nameof( name )} string must not be null or empty" );
        }
        return name;
    }
}
