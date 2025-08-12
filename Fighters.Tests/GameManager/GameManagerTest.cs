using Fighters.Extensions;
using Fighters.Factories.ClassFactory;
using Fighters.Factories.RaceFactory;
using Fighters.Factories.WeaponFactory;
using Fighters.Factories.ArmorFactory;
using Fighters.Logger;
using Moq;

namespace Fighters.Tests.GameManager;

[TestFixture]
public class GameManagerTest
{
    private Mock<IFightersLogger> _loggerMock = new Mock<IFightersLogger>();

    [Test]
    public void AddFighter_ValidFighter_ShouldBeAdded()
    {
        var gameManager = new Fighters.GameManager.GameManager( _loggerMock.Object );

        var fighterDTO = new FighterEnumConfig(
            "Elf",
            Race.Elf,
            Class.Assassin,
            Weapon.Katana,
            Armor.LeatherArmor );

        gameManager.AddFighter( fighterDTO );

        Assert.AreEqual( 1, gameManager.GetFighters().Count );
    }
}
