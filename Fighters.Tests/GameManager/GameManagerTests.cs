using System.Reflection.Emit;
using Fighters.Extensions;
using Fighters.Factories.ArmorFactory;
using Fighters.Factories.ClassFactory;
using Fighters.Factories.RaceFactory;
using Fighters.Factories.WeaponFactory;
using Fighters.Logger;
using Fighters.Models.Fighters;
using Moq;

namespace Fighters.Tests.GameManager;

[TestFixture]
public class GameManagerTests
{
    private Mock<IFightersLogger> _loggerMock;
    private Fighters.GameManager.GameManager _gameManager;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<IFightersLogger>();
        _gameManager = new Fighters.GameManager.GameManager( _loggerMock.Object );
    }

    [Test]
    public void AddFighter_ValidFighter_FighterIsAdded()
    {
        _gameManager.AddFighter( CreateMockFighter() );

        Assert.AreEqual( 1, _gameManager.GetFighters().Count );
    }

    [Test]
    public void RemoveFighter_ExistingFighter_FighterIsRemoved()
    {
        _gameManager.AddFighter( CreateMockFighter() );
        IFighter fighter = _gameManager.GetFighters().FirstOrDefault();

        _gameManager.RemoveFighter( fighter );

        Assert.AreEqual( 0, _gameManager.GetFighters().Count );
    }

    [Test]
    public void RemoveFighter_UnexistingFighter_TheCounterOfFighterIsTheSame()
    {
        _gameManager.AddFighter( CreateMockFighter() );

        IFighter fighter = _gameManager.GetFighters().First();


        _gameManager.RemoveFighter( fighter );

        Assert.AreEqual( 0, _gameManager.GetFighters().Count );
    }

    [Test]
    public void RemoveAllFighters_ExisitingFighters_TheCountOfFighterIsZero()
    {
        _gameManager.AddFighter( CreateMockFighter() );
        _gameManager.AddFighter( CreateMockFighter() );
        _gameManager.AddFighter( CreateMockFighter() );
        _gameManager.AddFighter( CreateMockFighter() );

        _gameManager.RemoveAllFighters();

        Assert.AreEqual( 0, _gameManager.GetFighters().Count );
    }

    [Test]
    public void RemoveDeadFighters_ExisitingFighters_DeadDeleted()
    {
        _gameManager.AddFighter( CreateMockDeadFighter() );
        _gameManager.AddFighter( CreateMockFighter() );
        List<IFighter> fighters = _gameManager.GetFighters();
        fighters[ 0 ].ReduceHealth( fighters[0].GetMaxHealth() );

        _gameManager.RemoveDeadFighters();

        Assert.AreEqual( 1, _gameManager.GetFighters().Count );
    }

    private FighterEnumConfig CreateMockFighter()
    {
        return new FighterEnumConfig(
            Name: "TestFighter",
            Race: Race.Human,
            Class: Class.Barbarian,
            Weapon: Weapon.Katana,
            Armor: Armor.NoAmrom
            );
    }

    private FighterEnumConfig CreateMockDeadFighter()
    {
        return new FighterEnumConfig(
            Name: "Deadfighter",
            Race: Race.Human,
            Class: Class.Barbarian,
            Weapon: Weapon.Katana,
            Armor: Armor.NoAmrom
            );
    }
}
