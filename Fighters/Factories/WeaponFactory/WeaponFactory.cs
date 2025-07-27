using Fighters.Models.Weapons;

namespace Fighters.Factories.WeaponFactory;

public class WeaponFactory : IWeaponfactory
{
    public IWeapon Create( Weapons weapon )
    {
        switch ( weapon )
        {
            case Weapons.Fists:
                return new Fists();
            case Weapons.Katana:
                return new Katana();
            case Weapons.Knife:
                return new Knife();
            case Weapons.MagicStaff:
                return new MagicStaff();
            case Weapons.Sword:
                return new Sword();
            default:
                throw new NotImplementedException( "Invalid weapon" );
        }
    }
}