using System.Globalization;
using System.Xml.Linq;

namespace Domain.Entities;
public class Guest
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }  
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public List<Reservation> Reservations { get; private set; } = new List<Reservation>();

    public Guest( string firstName, string lastName, string phone, string email )
    {
        FirstName = SetString( firstName );
        LastName = SetString( lastName );
        SetPhone( phone );
        SetEmail( email );
    }

    protected Guest() { }

    public string SetString( string name )
    {
        if ( String.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentNullException( $"{nameof( name )} must not be null or empty." );
        }
        return name;
    }

    public void SetPhone( string phone )
    {
        if ( String.IsNullOrWhiteSpace( phone ) )
        {
            throw new ArgumentNullException( $"{nameof( phone )} must not be null or empty." );
        }
        PhoneNumber = phone;
    }

    public void SetEmail( string email )
    {
        if ( String.IsNullOrWhiteSpace( email ) )
        {
            throw new ArgumentNullException( $"{nameof( email )} must not be null or empty." );
        }
        Email = email;
    }
}
