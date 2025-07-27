using Fighters.Models.Armors;
using Fighters.Models.Class;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Extensions
{
    public record FighterConfig(
        string Name,
        IRace Race,
        IClass Class,
        IWeapon Weapon,
        IArmor Armor );
}
