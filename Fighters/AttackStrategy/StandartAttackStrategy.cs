using Fighters.Models.Fighters;

namespace Fighters.AtackStrategy
{
    public class StandartAttackStrategy : IAttackStrategy
    {
        private Random _rnd = new Random();
        private const double minDamage = 0.6;
        private const double maxDamage = 1.0;
        private const double criticalChance = 0.2;
        private const double criticalMultiplier = 1.5;
        public int CalculateDamage( int baseDamage, IFighter fighter )
        {
            var variation = _rnd.NextDouble() * ( maxDamage - minDamage ) + minDamage;
            var damage = ( int )( baseDamage * variation );
            bool isCritical = _rnd.NextDouble() < criticalChance;
            return isCritical ? ( int )( damage * criticalMultiplier ) : damage;
        }
    }
}
