using System.Xml.Linq;

namespace Domain.Entities;
public class Guest
{
    public int Id { get; private set; }
    public string FullName { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }


    public Guest( string name, string phone, string email )
    {
        SetName( name );
        SetPhone( phone );
        SetEmail( email );
    }

    protected Guest() { }

    public void SetName( string name )
    {
        if ( String.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentNullException( $"{nameof( name )} must not be null or empty." );
        }
        FullName = name;
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
