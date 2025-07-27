using System.Net.NetworkInformation;

namespace Fighters.AtackStrategy
{
    public class StandartAtackStrategy : IAtackStrategy
    {
        private Random _rnd = new Random();
        private const double minDamage = 0.8;
        private const double maxDamage = 1.1;
        private const double criticalChance = 0.3;
        private const double criticalMultiplier = 2.0;
        public int CalculateDamage( int baseDamage )
        {
            var variation = _rnd.NextDouble() * ( maxDamage - minDamage ) + minDamage;
            var damage = ( int )( baseDamage * variation );
            bool isCritical = _rnd.NextDouble() < criticalChance;
            return isCritical ? ( int )( damage * criticalMultiplier ) : damage;
        }
    }
}
