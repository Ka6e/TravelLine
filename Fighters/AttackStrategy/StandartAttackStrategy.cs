using Fighters.Models.Fighters;

namespace Fighters.AttackStrategy
{
    public class StandartAttackStrategy : IAttackStrategy
    {
        private Random _rnd = new Random();
        private const double minDamage = 0.6;
        private const double maxDamage = 1.0;
        private const double criticalChance = 0.2;
        private const double criticalMultiplier = 1.5;
        protected virtual double NextRandomDouble() => _rnd.NextDouble();

        public int CalculateDamage( int baseDamage, IFighter fighter )
        {
            var variation = NextRandomDouble() * ( maxDamage - minDamage ) + minDamage;
            var damage = ( int )( baseDamage * variation );
            bool isCritical = NextRandomDouble() < criticalChance;
            return isCritical ? ( int )( damage * criticalMultiplier ) : damage;
        }
    }
}
