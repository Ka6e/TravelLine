using Fighters.Models.Races;
namespace Fighters.Factories.RaceFactory;


public class RaceFactory : IRaceFactory
{
    public IRace Create( Race race )
    {
        switch ( race )
        {
            case Race.Elf:
                return new Elf();
            case Race.Goblin:
                return new Goblin();
            case Race.Human:
                return new Human();
            case Race.Orc:
                return new Orc();
            default:
                throw new NotImplementedException( "Invalid race" );
        }
    }
}
