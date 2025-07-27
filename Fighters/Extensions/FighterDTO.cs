using Fighters.Factories.ArmorFactory;
using Fighters.Factories.ClassFactory;
using Fighters.Factories.RaceFactory;
using Fighters.Factories.WeaponFactory;

namespace Fighters.Extensions
{
    public record FighterDTO(
        string Name,
        Races Race,
        Classes Class,
        Weapons Weapon,
        Armors Armor );
}
