using System.Numerics;

namespace Domain.Entities;
public class Service
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public bool IsActive { get; private set; }

    public Service( string name, decimal price, bool isActive )
    {
        SetName( name );
        SetPrice( price );
        SetActive( isActive );
    }

    public void SetName( string name )
    {
        if ( String.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentNullException( $"{nameof( name )} string must not be null or empty" );
        }
        Name = name;
    }

    public void SetPrice( decimal price )
    {
        if ( price <= 0 )
        {
            throw new ArgumentException( $"{nameof( price )} must be greater than zero" );
        }
        Price = price;
    }

    public void SetActive( bool isActive )
    {
        IsActive = isActive;
    }
}
