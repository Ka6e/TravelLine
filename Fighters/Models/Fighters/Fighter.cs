using Fighters.AttackStrategy;
using Fighters.Extensions;
using Fighters.Models.Armors;
using Fighters.Models.Classes;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters
{
    public class Fighter : IFighter
    {
        public string Name { get; }
        public int Defence { get; }
        public int Strength { get; }
        public int Initiative { get; }
        public bool IsAlive => _health > 0;
        public IArmor Armor { get; }
        public IWeapon Weapon { get; }
        public IRace Race { get; }
        public IClass Class { get; }

        private int _health;
        private int _maxHealth;
        private IAttackStrategy _atackStrategy = new StandartAttackStrategy();

        public Fighter( FighterConfig config )
        {
            Name = config.Name;
            Race = config.Race;
            Class = config.Class;
            Weapon = config.Weapon;
            Armor = config.Armor;
            Initiative = config.Class.Initiative;
            _maxHealth = Race.Health + Class.Health;
            Defence = Race.Armor + Armor.Defence;
            Strength = Race.Strength + Class.Strength + Weapon.Strength;
            _health = _maxHealth;
        }

        public void HealFull() => _health = _maxHealth;

        public void SetAttackStrategy( IAttackStrategy strategy ) => _atackStrategy = strategy;

        public int Attack() => _atackStrategy.CalculateDamage( Strength, this );

        public int GetCurrentHealth() => _health;

        public int GetMaxHealth() => _maxHealth;

        public int TakeDamage( int damage )
        {
            int realDamage = Math.Max( damage - Defence, 0 );
            _health = Math.Max( 0, _health - realDamage );
            return realDamage;
        }

        public IClass GetClass() => Class;

        public void Heal( int healAmount )
        {
            _health += healAmount;
        }

        public void ReduceHealth( int amount )
        {
            _health = Math.Max( 0, _health - amount );
        }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Health: {_health}/{_maxHealth}\n" +
                $"Strength: {Strength}\n" +
                $"Armor: {Armor}\n" +
                $"Initiative: {Initiative}\n" +
                $"Race: {Race.GetType().Name}\n" +
                $"Class: {Class.GetType().Name}\n" +
                $"Weapon: {Weapon.GetType().Name}\n" +
                $"ArmorType: {Armor.GetType().Name}\n" +
                $"Status: {( IsAlive ? "Alive" : "Dead" )}\n";
        }
    }
}