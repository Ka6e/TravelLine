using Fighters.Builder;
using Fighters.Extensions;
using Fighters.Factories.ArmorFactory;
using Fighters.Factories.ClassFactory;
using Fighters.Factories.RaceFactory;
using Fighters.Factories.WeaponFactory;
using Fighters.Logger;
using Fighters.Models.Fighters;

namespace Fighters.GameManager
{
    public class GameManager
    {
        private readonly RaceFactory _raceFactory = new();
        private readonly WeaponFactory _weaponFactory = new();
        private readonly ClassFactory _classFactory = new();
        private readonly ArmorFactory _armorFactory = new();
        private List<IFighter> _fighters = new();
        private GameEngine.GameEngine _engine;

        public GameManager( IFightersLogger logger )
        {
            _engine = new GameEngine.GameEngine( logger );
        }

        public void ShowFighters()
        {
            foreach ( var fighter in _fighters )
            {
                Console.WriteLine( fighter.ToString() );
            }
        }

        public void AddFighter( FighterEnumConfig fighterDTO )
        {
            var builder = new FighterBuilder();
            var result = builder.SetName( fighterDTO.Name )
                .SetRace( _raceFactory.Create( fighterDTO.Race ) )
                .SetClass( _classFactory.Create( fighterDTO.Class ) )
                .SetWeapon( _weaponFactory.Create( fighterDTO.Weapon ) )
                .SetArmor( _armorFactory.Create( fighterDTO.Armor ) )
                .Build();
            _fighters.Add( result );
        }

        public List<IFighter> GetFighters()
        {
            return _fighters;
        }

        public void Fight()
        {
            _engine.RunBattle( _fighters );
        }

        public void RemoveAllFighters()
        {
            if ( _fighters.Count != 0 )
            {
                _fighters.Clear();
            }
        }

        public void RemoveDeadFighters()
        {
            if ( _fighters.Count != 0 )
            {
                _fighters.RemoveAll( x => !x.IsAlive );
            }
        }

        public void RemoveFighter( IFighter fighter )
        {
            if ( _fighters.Contains( fighter ) )
            {
                _fighters.Remove( fighter );
            }
        }
    }
}
