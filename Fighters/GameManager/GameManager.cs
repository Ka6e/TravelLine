using Fighters.Builder;
using Fighters.Engine;
using Fighters.Extensions;
using Fighters.Factories.ArmorFactory;
using Fighters.Factories.ClassFactory;
using Fighters.Factories.RaceFactory;
using Fighters.Factories.WeaponFactory;
using Fighters.Logger;
using Fighters.Models.Fighters;

namespace Fighters.Manager
{
    public class GameManager
    {
        private readonly RaceFactory _raceFactory = new();
        private readonly WeaponFactory _weaponFactory = new();
        private readonly ClassFactory _classFactory = new();
        private readonly ArmorFactory _armorFactory = new();
        private List<Fighter> _fighters = new();
        private GameEngine _engine;

        public GameManager( IFightersLogger logger )
        {
            _engine = new GameEngine( logger );
        }
        public void ShowFighters()
        {
            foreach ( var fighter in _fighters )
            {
                Console.WriteLine( fighter.ToString() );
            }
        }

        public void AddFighter( FighterDTO fighterDTO )
        {
            var builder = new FighterBuilder();
            var cfg = BuildConfig( fighterDTO );
            var result = builder.SetName( cfg.Name )
                .SetRace( cfg.Race )
                .SetClass( cfg.Class )
                .SetWeapon( cfg.Weapon )
                .SetArmor( cfg.Armor )
                .Build();

            _fighters.Add( result.value );
        }

        public void Fight()
        {
            _engine.RunBattle( _fighters );
        }

        private FighterConfig BuildConfig( FighterDTO fighterDTO )
        {
            var cfg = new FighterConfig(
                fighterDTO.Name,
                _raceFactory.Create( fighterDTO.Race ),
                _classFactory.Create( fighterDTO.Class ),
                _weaponFactory.Create( fighterDTO.Weapon ),
                _armorFactory.Create( fighterDTO.Armor )
                );
            return cfg;
        }
    }
}
