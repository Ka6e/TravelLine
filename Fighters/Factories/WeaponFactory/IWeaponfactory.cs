using Fighters.Models.Weapons;

namespace Fighters.Factories.WeaponFactory
{
    public interface IWeaponFactory
    {
        IWeapon Create( Weapon weapon );
    }
}
