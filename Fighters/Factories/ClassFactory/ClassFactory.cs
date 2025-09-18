using Fighters.Models.Classes;
using Fighters.Models.Fighters;

namespace Fighters.Factories.ClassFactory;

public class ClassFactory : IClassFactory
{
    public IClass Create( Class @class )
    {
        return @class switch
        {
            Class.Assassin => new Assassin(),
            Class.Barbarian => new Barbarian(),
            Class.Knight => new Knight(),
            Class.Samurai => new Samurai(),
            Class.Thief => new Thief(),
            Class.Wizzard => new Wizzard(),
            _ => throw new ArgumentException( "Invalid class.", nameof( @class ) )
        };
    }
}
