using Fighters.Builder;
using Fighters.Models.Fighters;

namespace Fighters.Engine
{
    public class GameEngine
    {
        private List<Fighter> _fighters = new();
        private FighterBuilder _builder;
        private int _round = 1;
        private Random _random = new Random();

        public List<Fighter> GetFighters()
        {
            return _fighters;
        }

        public void RunBattle()
        {
            if ( IsEnoughFighters( _fighters ) )
            {
                Console.WriteLine( "Not enough fighters." );
                return;
            }

            while ( _fighters.Count > 1 )
            {

            }
        }

        private Fighter RunDuel( Fighter first, Fighter second )
        {
            var order = new[] { first, second }
            .OrderByDescending( x => x.Initiative )
            .ToList();

            var attacker = order[ 0 ];
            var defender = order[ 1 ];

            int round = 1;
            while ( attacker.IsAlive && defender.IsAlive )
            {
                ExecuteAtack( attacker, defender );
                if ( second.IsAlive )
                {
                    ExecuteAtack(defender, attacker );
                }
                round++;
            }
            return attacker.IsAlive ? attacker : defender;
        }
        private void ExecuteAtack( Fighter attacker, Fighter defender )
        {
            int damage = attacker.Atack();
            int realDamage = defender.TakeDamage( damage );

            Console.WriteLine( $"{attacker.Name} attacks {defender.Name} for {damage} damage ({realDamage} real after armor)." );
        }
        private bool IsEnoughFighters( List<Fighter> fighters )
        {
            return fighters.Count > 2;
        }

    }
}
