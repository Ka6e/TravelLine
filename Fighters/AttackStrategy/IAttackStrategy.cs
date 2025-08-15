using Fighters.Models.Fighters;

namespace Fighters.AttackStrategy
{
    public interface IAttackStrategy
    {
        int CalculateDamage( int baseDamage, IFighter fighter );
    }
}
