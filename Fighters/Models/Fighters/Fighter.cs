using Fighters.AttackStrategy;
using Fighters.Extensions;
using Fighters.Models.Armors;
using Fighters.Models.Class;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters
{
    public class Fighter : IFighter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Strength { get; set; }
        public int Initiative { get; private set; }
        public bool IsAlive => Health > 0;

        //private int _currentHealth;
        //private int _totalStrength;
        //private int _totalArmor;
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
            Initvariables( config.Race, config.Class, config.Weapon, config.Armor );
        }

        public void HealFull() => Health = _maxHealth;

        public void SetAttackStrategy( IAttackStrategy strategy ) => _atackStrategy = strategy;

        public int Attack() => _atackStrategy.CalculateDamage( Strength, this );

        public int GetCurrentHealth() => Health;

        public int GetMaxHealth() => _maxHealth;

        public int TakeDamage( int damage )
        {
            int realDamage = Math.Max( damage - Armor, 0 );
            //_currentHealth = Math.Max( 0, _currentHealth - realDamage );
            Health = Math.Max( 0, Health - realDamage );
            return realDamage;
        }

        public IClass GetClass() => _class;
        public void Heal( int healAmount )
        {
            //_currentHealth += healAmount;
            Health += healAmount;
        }

        public IAttackStrategy GetAttackStrategy() => _atackStrategy;
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Health: {Health}/{_maxHealth}\n" +
                $"Strength: {Strength}\n" +
                $"Armor: {Armor}\n" +
                $"Initiative: {Initiative}\n" +
                $"Race: {_race.GetType().Name}\n" +
                $"Class: {_class.GetType().Name}\n" +
                $"Weapon: {_weapon.GetType().Name}\n" +
                $"ArmorType: {_armor.GetType().Name}\n" +
                $"Status: {( IsAlive ? "Alive" : "Dead" )}\n";
        }

        private void Initvariables( IRace race, IClass @class, IWeapon weapon, IArmor armor )
        {
            _maxHealth = race.Health + @class.Health;
            Armor = armor.Defence + race.Armor;
            Strength = race.Strength + @class.Strength + weapon.Strength;
            Health = _maxHealth;
            //_totalStrength = race.Strength + @class.Strength + weapon.Strength;
            //_totalArmor = armor.Defence + race.Armor;
            //_maxHealth = race.Health + @class.Health;
            //_currentHealth = _maxHealth;
        }
    }
}