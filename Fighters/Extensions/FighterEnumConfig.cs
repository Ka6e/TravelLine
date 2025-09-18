using Fighters.Factories.ArmorFactory;
using Fighters.Factories.ClassFactory;
using Fighters.Factories.RaceFactory;
using Fighters.Factories.WeaponFactory;

namespace Fighters.Extensions
{
    public record FighterEnumConfig(
        string Name,
        Race Race,
        Class Class,
        Weapon Weapon,
        Armor Armor );
}
