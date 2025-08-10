using Fighters.Models.Armors;

namespace Fighters.Factories.ArmorFactory;

public class ArmorFactory : IArmorFactory
{
    public IArmor Create( Armor armor )
    {
        return armor switch
        {
            Armor.NoAmrom => new NoArmor(),
            Armor.LeatherArmor => new LeatherArmor(),
            Armor.ChainMail => new ChainMail(),
            Armor.IronArmor => new IronArmor(),
            Armor.PlateArmor => new PlateArmor(),
            _ => throw new ArgumentException( "Invalid armor", nameof( armor ) )
        };
    }
}
