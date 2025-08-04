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
        public int Armor { get; }
        public int Strength { get; }
        public int Initiative { get; }
        public bool IsAlive => _health > 0;

        private int _health;
        private int _maxHealth;
        private IArmor _armor;
        private IWeapon _weapon;
        private IRace _race;
        private IClass _class;
        private IAttackStrategy _atackStrategy = new StandartAttackStrategy();

        public Fighter( FighterConfig config )
        {
            Name = config.Name;
            _race = config.Race;
            _class = config.Class;
            _weapon = config.Weapon;
            _armor = config.Armor;
            Initiative = config.Class.Initiative;
            _maxHealth = _race.Health + _class.Health;
            Armor = _race.Armor + _armor.Defence;
            Strength = _race.Strength + _class.Strength + _weapon.Strength;
            _health = _maxHealth;
        }

        public void HealFull() => _health = _maxHealth;

        public void SetAttackStrategy( IAttackStrategy strategy ) => _atackStrategy = strategy;

        public int Attack() => _atackStrategy.CalculateDamage( Strength, this );

        public int GetCurrentHealth() => _health;

        public int GetMaxHealth() => _maxHealth;

        public int TakeDamage( int damage )
        {
            int realDamage = Math.Max( damage - Armor, 0 );
            _health = Math.Max( 0, _health - realDamage );
            return realDamage;
        }

        public IClass GetClass() => _class;

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
                $"Race: {_race.GetType().Name}\n" +
                $"Class: {_class.GetType().Name}\n" +
                $"Weapon: {_weapon.GetType().Name}\n" +
                $"ArmorType: {_armor.GetType().Name}\n" +
                $"Status: {( IsAlive ? "Alive" : "Dead" )}\n";
        }
    }
}