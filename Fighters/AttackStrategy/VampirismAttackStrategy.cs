using Fighters.Models.Fighters;

namespace Fighters.AttackStrategy
{
    public class VampirismAttackStrategy : IAttackStrategy
    {
        private Random _random = new Random();

        public int CalculateDamage( int baseDamage, Fighter fighter )
        {
            int damage = ( int )( baseDamage * ( _random.NextDouble() * 0.5 + 0.75 ) );
            int heal = ( damage / 3 );
            fighter.Heal( heal );

            return damage;
        }
    }
}
