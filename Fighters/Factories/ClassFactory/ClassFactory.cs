using Fighters.Models.Class;
using Fighters.Models.Fighters;

namespace Fighters.Factories.ClassFactory;

public class ClassFactory : IClassFactory
{
    public IClass Create( Class @class )
    {
        switch ( @class )
        {
            case Class.Assassin:
                return new Assassin();
            case Class.Barbarian:
                return new Barbarian();
            case Class.Knight:
                return new Knight();
            case Class.Samurai:
                return new Samurai();
            case Class.Thief:
                return new Thief();
            case Class.Wizzard:
                return new Wizzard();
            default:
                throw new NotImplementedException( "Invalid class." );
        }
    }
}
