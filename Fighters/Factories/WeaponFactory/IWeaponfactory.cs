using Fighters.Models.Weapons;

namespace Fighters.Factories.WeaponFactory
{
    public interface IWeaponfactory
    {
        IWeapon Create( Weapon weapon );
    }
}
