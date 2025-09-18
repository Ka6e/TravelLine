using Fighters.Models.Classes;

namespace Fighters.Factories.ClassFactory
{
    public interface IClassFactory
    {
        IClass Create( Class @class );
    }
}
