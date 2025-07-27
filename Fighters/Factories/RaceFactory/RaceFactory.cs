using Fighters.Models.Races;
namespace Fighters.Factories.RaceFactory;


public class RaceFactory : IRaceFactory
{
    public IRace Create( Races race )
    {
        switch ( race )
        {
            case Races.Elf:
                return new Elf();
            case Races.Goblin:
                return new Goblin();
            case Races.Human:
                return new Human();
            case Races.Orc:
                return new Orc();
            default:
                throw new NotImplementedException( "Invalid race" );
        }
    }
}
