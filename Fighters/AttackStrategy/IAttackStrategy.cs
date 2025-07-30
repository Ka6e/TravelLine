using Fighters.Models.Fighters;

namespace Fighters.AtackStrategy
{
    public interface IAttackStrategy
    {
        int CalculateDamage( int damage, IFighter fighter );
    }
}
