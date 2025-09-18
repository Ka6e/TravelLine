using Fighters.Models.Armors;

namespace Fighters.Factories.ArmorFactory
{
    public interface IArmorFactory
    {
        IArmor Create( Armor armor );
    }
}
