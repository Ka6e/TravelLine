using Fighters.AttackStrategy;
using Fighters.Models.Fighters;
using Moq;

namespace Fighters.Tests.AttackStrategy;

[TestFixture]
public class AttacksStrategiesTests
{
    [Test]
    public void CalculateDamage_FighterUsesVampirismStrategy_HealsFighterByOneOfThirdOfDamage()
    {
        Mock<IFighter> fighterMock = FighterMock.FighterMock.CreateMockFighter( currentHealth: 40 );
        IAttackStrategy attackStrategy = new VampirismAttackStrategy();
        int baseDamage = 10;
        int healthBefore = fighterMock.Object.GetCurrentHealth();

        int damage = attackStrategy.CalculateDamage( baseDamage, fighterMock.Object );
        int healthAfter = fighterMock.Object.GetCurrentHealth();

        int expectedHeal = damage / 3;
        Assert.AreEqual( healthBefore + expectedHeal, healthAfter );
    }

    [Test]
    public void CalculateDamage_RandomValueLessPointOne_BarbarianInjuresHimselfByTenHP()
    {
        Mock<IFighter> barbarian = FighterMock.FighterMock.CreateMockFighter( currentHealth: 20 );
        IAttackStrategy attackStrategy = new BerserkAttackStrategyStub( 0.05 );
        int baseDamage = 20;
        int healthBefore = barbarian.Object.GetCurrentHealth();

        int damage = attackStrategy.CalculateDamage( baseDamage, barbarian.Object );

        int expectedHP = barbarian.Object.GetCurrentHealth();
        Assert.AreEqual( healthBefore - 10, expectedHP );
    }

    [Test]
    public void CalculateDamage_RandomValueGreatePointOne_BarbarianAttacksWithDoubleDamage()
    {
        Mock<IFighter> barbarian = FighterMock.FighterMock.CreateMockFighter( currentHealth: 50 );
        IAttackStrategy attackStrategy = new BerserkAttackStrategyStub( 0.5 );
        int baseDamage = 10;

        int damage = attackStrategy.CalculateDamage( baseDamage, barbarian.Object );

        Assert.AreEqual( baseDamage * 2, damage );
    }

    [Test]
    public void CalcualteDamage_RandomValueLessCriticalChance_FighterAttackHarder()
    {
        Mock<IFighter> figter = FighterMock.FighterMock.CreateMockFighter();
        IAttackStrategy attackStrategy = new StandartAttackStrategyStub( 0.1 );
        int baseDamage = 10;

        int damage = attackStrategy.CalculateDamage( baseDamage, figter.Object );

        Assert.AreEqual( 9, damage );
    }

    [Test]
    public void CalculateDamage_RandomValueGreaterCriticalChance_FighterAttacksWeaker()
    {
        Mock<IFighter> fighter = FighterMock.FighterMock.CreateMockFighter();
        IAttackStrategy attackStrategy = new StandartAttackStrategyStub( 0.5 );
        int baseDamage = 10;

        int damage = attackStrategy.CalculateDamage( baseDamage, fighter.Object );

        Assert.AreEqual( 8, damage );
    }

    [Test]
    public void CalcualteDamage_RandomValueLessCriticalChance_FighterAttacksWithHardRageStrategy()
    {
        Mock<IFighter> fighter = FighterMock.FighterMock.CreateMockFighter();
        IAttackStrategy attackStrategy = new RageAttackStrategyStub( 0.1 );
        int baseDamage = 10;

        int damage = attackStrategy.CalculateDamage(baseDamage, fighter.Object);

        Assert.AreEqual( 20, damage );
    }

    [Test]
    public void CalcualteDamage_RandomValueGreaterCriticalChance_FighterAttacksWithWeakRageStrategy()
    {
        Mock<IFighter> fighter = FighterMock.FighterMock.CreateMockFighter();
        IAttackStrategy attackStrategy = new RageAttackStrategyStub( 1.0 );
        int baseDamage = 10;

        int damage = attackStrategy.CalculateDamage(baseDamage, fighter.Object);

        Assert.AreEqual( 15, damage );
    }

    private class BerserkAttackStrategyStub : BerserkAttackStrategy
    {
        private readonly double _value;
        public BerserkAttackStrategyStub( double value ) => _value = value;
        protected override double NextRandomDouble() => _value;
    }

    private class StandartAttackStrategyStub : StandartAttackStrategy
    {
        private readonly double _value;
        public StandartAttackStrategyStub( double value ) => _value = value;
        protected override double NextRandomDouble() => _value;
    }

    private class RageAttackStrategyStub : RageAttackStrategy
    {
        private readonly double _value;
        public RageAttackStrategyStub( double value ) => _value = value;
        protected override double NextRandomDouble() => _value;
    }
}
