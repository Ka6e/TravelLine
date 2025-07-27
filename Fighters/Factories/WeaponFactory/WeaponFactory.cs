using Fighters.Models.Weapons;

namespace Fighters.Factories.WeaponFactory;

public class WeaponFactory : IWeaponfactory
{
    public IWeapon Create( Weapon weapon )
    {
        switch ( weapon )
        {
            case Weapon.Fists:
                return new Fists();
            case Weapon.Katana:
                return new Katana();
            case Weapon.Knife:
                return new Knife();
            case Weapon.MagicStaff:
                return new MagicStaff();
            case Weapon.Sword:
                return new Sword();
            default:
                throw new NotImplementedException( "Invalid weapon" );
        }
    }
}