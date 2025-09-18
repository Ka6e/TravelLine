using Fighters.Models.Races;

namespace Fighters.Factories.RaceFactory;

public class RaceFactory : IRaceFactory
{
    public IRace Create( Race race )
    {
        return race switch
        {
            Race.Elf => new Elf(),
            Race.Goblin => new Goblin(),
            Race.Human => new Human(),
            Race.Orc => new Orc(),
            _ => throw new ArgumentException( "Invalid race", nameof( race ) )
        };
    }
}
