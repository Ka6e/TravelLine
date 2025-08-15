using Fighters.AttackStrategy;
using Fighters.Logger;
using Fighters.Models.Classes;
using Fighters.Models.Fighters;
using Moq;

namespace Fighters.Tests.GameEngine;

[TestFixture]
public class GameEngineTests
{
    private Mock<IFightersLogger> _loggerMock;
    private Fighters.GameEngine.GameEngine _gameEngine;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<IFightersLogger>();
        _gameEngine = new Fighters.GameEngine.GameEngine( _loggerMock.Object );
    }

    [TestCase( 0 )]
    [TestCase( 1 )]
    public void RunBattle_NotEnoughFigters_LogsError( int fighterCount )
    {
        List<IFighter> fighters = new List<IFighter>();
        for ( int i = 0; i < fighterCount; i++ )
        {
            fighters.Add( FighterMock.FighterMock.CreateMockFighter().Object );
        }

        _gameEngine.RunBattle( fighters );

        _loggerMock.Verify(
            log => log.LogError( It.Is<string>( msg =>
            msg.Contains( "Not enough fighters. You need at least 2 fighters. It's only " ) &&
            msg.Contains( $"{fighterCount} now" ) ) ),
            Times.Once );
    }

    [Test]
    public void RunBattle_BarbarianLowHP_BarbariabSetsBerserkAttackStrategy()
    {
        Mock<IFighter> barbarian = FighterMock.FighterMock.CreateMockFighter( currentHealth: 20, @class: new Barbarian() );
        Mock<IFighter> defender = FighterMock.FighterMock.CreateMockFighter();
        List<IFighter> fighters = new List<IFighter> { barbarian.Object, defender.Object };

        _gameEngine.RunBattle( fighters );

        barbarian.Verify(
            f => f.SetAttackStrategy( It.Is<BerserkAttackStrategy>( s => s != null ) ),
            Times.AtLeastOnce,
            "Barbarian with low HP should switch to BerserkAttackStrategy"
        );
    }

    [TestCase( typeof( StandartAttackStrategy ) )]
    [TestCase( typeof( VampirismAttackStrategy ) )]
    [TestCase( typeof( RageAttackStrategy ) )]
    public void RunBattle_BarbarionLowHP_BarbarianDoesntSetDefaultStrategies( Type strategy )
    {
        Mock<IFighter> barbarian = FighterMock.FighterMock.CreateMockFighter( currentHealth: 20, @class: new Barbarian() );
        Mock<IFighter> defender = FighterMock.FighterMock.CreateMockFighter();
        List<IFighter> fighters = new List<IFighter> { barbarian.Object, defender.Object };

        _gameEngine.RunBattle( fighters );

        barbarian.Verify(
            x => x.SetAttackStrategy( It.Is<IAttackStrategy>( s => s.GetType() == strategy ) ),
            Times.Never,
            $"Barbarian with low HP shouln't set {strategy.Name}"
        );
    }

    [Test]
    public void RunBattle_FighterHighInitiative_AttackFirts()
    {
        Mock<IFighter> highInitFighter = FighterMock.FighterMock.CreateMockFighter( name: "High", initiative: 20 );
        Mock<IFighter> lowInitFighter = FighterMock.FighterMock.CreateMockFighter( name: "Low", initiative: 10 );
        List<IFighter> fighters = new List<IFighter> { highInitFighter.Object, lowInitFighter.Object };

        _gameEngine.RunBattle( fighters );

        _loggerMock.Verify(
            l => l.Log( It.Is<string>(
                s => s.Contains( "Round of duel" ) || s.Contains( "High attacks Low" ) ) ),
            Times.AtLeastOnce );
    }

    [Test]
    public void RunBattle_FighterLowHP_FightersSetsRageAttackStrategy()
    {
        Mock<IFighter> attacker = FighterMock.FighterMock.CreateMockFighter( currentHealth: 20 );
        Mock<IFighter> defender = FighterMock.FighterMock.CreateMockFighter();
        List<IFighter> fighters = new List<IFighter> { attacker.Object, defender.Object };

        _gameEngine.RunBattle( fighters );

        attacker.Verify(
            x => x.SetAttackStrategy( It.Is<RageAttackStrategy>( s => s != null ) ),
            Times.AtLeastOnce,
            "Fighter with low HP should switch to RageAttackStrategy"
        );
    }

    [TestCase( typeof( BerserkAttackStrategy ) )]
    [TestCase( typeof( StandartAttackStrategy ) )]
    [TestCase( typeof( VampirismAttackStrategy ) )]
    public void RunBattle_FighterLowHP_FighterDoesntSetThisStrategy( Type strategy )
    {
        Mock<IFighter> attacker = FighterMock.FighterMock.CreateMockFighter( currentHealth: 20 );
        Mock<IFighter> defender = FighterMock.FighterMock.CreateMockFighter();
        List<IFighter> fighters = new List<IFighter> { attacker.Object, defender.Object };

        _gameEngine.RunBattle( fighters );

        attacker.Verify(
            x => x.SetAttackStrategy( It.Is<IAttackStrategy>( s => s.GetType() == strategy ) ),
            Times.Never,
            $"Fighter with low HP shouldn't set {strategy.Name}"
        );
    }

    [Test]
    public void RunBattle_BattleOver_WinnerHealToFull()
    {
        Mock<IFighter> attacker = FighterMock.FighterMock.CreateMockFighter();
        Mock<IFighter> defender = FighterMock.FighterMock.CreateMockFighter( currentHealth: 10 );
        var list = new List<IFighter> { attacker.Object, defender.Object };

        _gameEngine.RunBattle( list );

        attacker.Verify( x => x.HealFull(), Times.AtLeastOnce );
    }

    [TestCase( typeof( StandartAttackStrategy ) )]
    [TestCase( typeof( VampirismAttackStrategy ) )]
    [TestCase( typeof( RageAttackStrategy ) )]
    public void RunBattle_DefaultFight_FighterSetsCorrectStrategy( Type expectedStrategyName )
    {
        Mock<IFighter> attacker = FighterMock.FighterMock.CreateMockFighter();
        Mock<IFighter> defender = FighterMock.FighterMock.CreateMockFighter();
        List<IFighter> fighters = new List<IFighter> { attacker.Object, defender.Object };

        _gameEngine.RunBattle( fighters );

        attacker.Verify(
            x => x.SetAttackStrategy( It.Is<IAttackStrategy>( s => s.GetType() == expectedStrategyName ) ),
            Times.AtLeastOnce
        );
    }


}
