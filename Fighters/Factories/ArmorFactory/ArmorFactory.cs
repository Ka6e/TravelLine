using Fighters.Models.Armors;

namespace Fighters.Factories.ArmorFactory;


public class ArmorFactory : IArmorFactory
{
    public IArmor Create( Armors armor )
    {
        switch ( armor )
        {
            case Armors.NoAmrom:
                return new NoArmor();
            case Armors.LeatherArmor:
                return new LeatherArmor();
            case Armors.ChainMail:
                return new ChainMail();
            case Armors.IronArmor:
                return new IronArmor();
            case Armors.PlateArmor:
                return new PlateArmor();
            default:
                throw new Exception( "Invalid armor" );
        }
    }
}
