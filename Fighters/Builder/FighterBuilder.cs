using Fighters.Extensions;
using Fighters.Models.Armors;
using Fighters.Models.Class;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Builder
{
    public class FighterBuilder : IFighterBuilder
    {
        private string _name;
        private IRace _race;
        private IClass _class;
        private IArmor _armor;
        private IWeapon _weapon;
        public IFighterBuilder SetName( string name )
        {
            _name = name;
            return this;
        }

        public IFighterBuilder SetArmor( IArmor armor )
        {
            _armor = armor;
            return this;
        }

        public IFighterBuilder SetClass( IClass @class )
        {
            _class = @class;
            return this;
        }

        public IFighterBuilder SetRace( IRace race )
        {
            _race = race;
            return this;
        }

        public IFighterBuilder SetWeapon( IWeapon weapon )
        {
            _weapon = weapon;
            return this;
        }

        public Fighter Build()
        {
            var config = new FighterConfig( _name, _race, _class, _weapon, _armor );
            var figter = new Fighter( config );
            return figter;
        }
    }
}
