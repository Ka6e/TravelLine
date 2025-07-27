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

        public BuilderResult<Fighter> Build()
        {
            if ( !IsValid( _name, _race, _class, _armor, _weapon ) )
            {
                return BuilderResult<Fighter>.Failure( "Not all parameters of the fighter are set." );
            }
            var config = new FighterConfig( _name, _race, _class, _weapon, _armor );
            var figter = new Fighter( config );
            return BuilderResult<Fighter>.Success( figter );
        }

        private bool IsValid( string name, IRace race, IClass @class, IArmor armor, IWeapon weapon )
        {
            if ( name == null
                || race == null
                || @class == null
                || armor == null
                || weapon == null )
            {
                return false;
            }
            return true;
        }
    }
}
