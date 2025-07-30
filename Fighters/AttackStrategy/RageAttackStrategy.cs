using Fighters.AtackStrategy;
using Fighters.Models.Fighters;

namespace Fighters.AttackStrategy
{
    public class RageAttackStrategy : IAttackStrategy
    {
        private Random _rnd = new Random();
        private const double minDamage = 1.0;
        private const double maxDamage = 1.5;
        private const double criticalChance = 0.5;
        private const double criticalMultiplier = 2.0;
        public int CalculateDamage( int baseDamage, IFighter fighter )
        {
            var variation = _rnd.NextDouble() * ( maxDamage - minDamage ) + minDamage;
            var damage = ( int )( baseDamage * variation );
            bool isCritical = _rnd.NextDouble() < criticalChance;
            return isCritical ? ( int )( damage * criticalMultiplier ) : damage;
        }
    }
}
