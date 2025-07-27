using Fighters.Models.Races;

namespace Fighters.Factories.RaceFactory
{
    public interface IRaceFactory
    {
        IRace Create( Races race );
    }
}
