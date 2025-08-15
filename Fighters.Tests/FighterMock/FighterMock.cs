using Fighters.AttackStrategy;
using Fighters.Models.Armors;
using Fighters.Models.Classes;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using Moq;

namespace Fighters.Tests.FighterMock;
public class FighterMock
{
    public static Mock<IFighter> CreateMockFighter(
        string name = "TestFighter",
        int maxHealth = 100,
        int currentHealth = 100,
        IClass @class = null,
        int damage = 10,
        int initiative = 5
        )
    {
        int hp = currentHealth;
        IClass usedClass = @class ?? Mock.Of<IClass>();

        Mock<IFighter> figter = new Mock<IFighter>();

        figter.Setup( x => x.Name ).Returns( name );
        figter.Setup( x => x.Initiative ).Returns( initiative );
        figter.Setup( x => x.IsAlive ).Returns( () => hp > 0 );
        figter.Setup( x => x.Race ).Returns( Mock.Of<IRace>() );
        figter.Setup( x => x.Class ).Returns( usedClass );
        figter.Setup( x => x.Weapon ).Returns( Mock.Of<IWeapon>() );
        figter.Setup( x => x.Armor ).Returns( Mock.Of<IArmor>() );
        figter.Setup( x => x.GetClass() ).Returns( usedClass );
        figter.Setup( x => x.GetCurrentHealth() ).Returns( () => hp );
        figter.Setup( x => x.GetMaxHealth() ).Returns( maxHealth );
        figter.Setup( x => x.Attack() ).Returns( damage );
        figter.Setup( x => x.ReduceHealth( It.IsAny<int>() ) )
            .Callback<int>( dmg => hp = Math.Max( 0, hp - dmg ) );
        figter.Setup( x => x.Heal( It.IsAny<int>() ) )
            .Callback<int>( heal => hp += heal );
        figter.Setup( x => x.TakeDamage( It.IsAny<int>() ) )
            .Callback<int>( dmg => hp = Math.Max( 0, hp - dmg ) )
            .Returns<int>( dmg => dmg );
        figter.Setup( x => x.HealFull() )
            .Callback( () => hp = maxHealth );
        figter.Setup( x => x.SetAttackStrategy( It.IsAny<IAttackStrategy>() ) );

        return figter;
    }
}
