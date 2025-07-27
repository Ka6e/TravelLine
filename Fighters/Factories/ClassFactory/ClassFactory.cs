using Fighters.Models.Class;
using Fighters.Models.Fighters;

namespace Fighters.Factories.ClassFactory;

public class ClassFactory : IClassFactory
{
    public IClass Create( Classes @class )
    {
        switch ( @class )
        {
            case Classes.Assassin:
                return new Assassin();
            case Classes.Barbarian:
                return new Barbarian();
            case Classes.Knight:
                return new Knight();
            case Classes.Samurai:
                return new Samurai();
            case Classes.Thief:
                return new Thief();
            case Classes.Wizzard:
                return new Wizzard();
            default:
                throw new NotImplementedException( "Invalid class." );
        }
    }
}
