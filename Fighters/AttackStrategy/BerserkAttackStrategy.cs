using Fighters.AtackStrategy;
using Fighters.Models.Fighters;

namespace Fighters.AttackStrategy
{
    public class BerserkAttackStrategy : IAttackStrategy
    {
        private Random _random = new Random();
        public int CalculateDamage( int baseDamage, IFighter fighter )
        {
            if ( _random.NextDouble() < 0.1 )
            {
                fighter.TakeDamage( 10 );
                return 0;
            }

            var damage = baseDamage * 2;
            return damage;
        }
    }
}
