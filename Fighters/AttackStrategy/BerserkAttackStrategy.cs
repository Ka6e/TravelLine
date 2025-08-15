using Fighters.Models.Fighters;

namespace Fighters.AttackStrategy
{
    public class BerserkAttackStrategy : IAttackStrategy
    {
        private Random _random = new Random();
        protected virtual double NextRandomDouble() => _random.NextDouble();
        public int CalculateDamage( int baseDamage, IFighter fighter )
        {
            if ( NextRandomDouble() < 0.1 )
            {
                fighter.ReduceHealth( 10 );
                return 0;
            }
            var damage = baseDamage * 2;
            return damage;
        }
    }
}
