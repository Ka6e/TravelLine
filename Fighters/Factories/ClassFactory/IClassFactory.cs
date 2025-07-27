using Fighters.Models.Class;

namespace Fighters.Factories.ClassFactory
{
    public interface IClassFactory
    {
        IClass Create( Classes @class );
    }
}
