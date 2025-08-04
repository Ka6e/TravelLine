using Fighters.Extensions;
using Fighters.Models.Armors;
using Fighters.Models.Classes;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Builder
{
    public interface IFighterBuilder
    {
        IFighterBuilder SetName( string name );
        IFighterBuilder SetClass( IClass @class );
        IFighterBuilder SetRace( IRace race );
        IFighterBuilder SetWeapon( IWeapon weapon );
        IFighterBuilder SetArmor( IArmor armor );
        Fighter Build();
    }
}
