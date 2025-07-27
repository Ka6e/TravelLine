using Fighters.Models.Armors;

namespace Fighters.Factories.ArmorFactory;


public class ArmorFactory : IArmorFactory
{
    public IArmor Create( Armor armor )
    {
        switch ( armor )
        {
            case Armor.NoAmrom:
                return new NoArmor();
            case Armor.LeatherArmor:
                return new LeatherArmor();
            case Armor.ChainMail:
                return new ChainMail();
            case Armor.IronArmor:
                return new IronArmor();
            case Armor.PlateArmor:
                return new PlateArmor();
            default:
                throw new Exception( "Invalid armor" );
        }
    }
}
