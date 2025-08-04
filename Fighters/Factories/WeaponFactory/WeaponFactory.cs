using Fighters.Models.Weapons;

namespace Fighters.Factories.WeaponFactory;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon Create( Weapon weapon )
    {
        return weapon switch
        {
            Weapon.Fists => new Fists(),
            Weapon.Katana => new Katana(),
            Weapon.Knife => new Knife(),
            Weapon.MagicStaff => new MagicStaff(),
            Weapon.Sword => new Sword(),
            _ => throw new ArgumentException( "Invalid weapon", nameof( weapon ) )
        };
    }
}