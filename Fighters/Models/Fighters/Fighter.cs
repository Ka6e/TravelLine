using Fighters.AtackStrategy;
using Fighters.Extensions;
using Fighters.Models.Armors;
using Fighters.Models.Class;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters
{
    public class Fighter : IFighter
    {
        public string Name { get; private set; }
        public int Initiative { get; protected set; }
        public bool IsAlive => _currentHealth > 0;

        private int _currentHealth;
        private int _totalStrength;
        private int _totalArmor;
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

        private void Initvariables( IRace race, IClass @class, IWeapon weapon, IArmor armor )
        {
            _totalStrength = race.Strength + @class.Strength + weapon.Strength;
            _totalArmor = armor.Defence + race.Armor;
            _maxHealth = race.Health + @class.Health;
            _currentHealth = _maxHealth;
        }

        public void SetAttackStrategy( IAttackStrategy strategy ) => _atackStrategy = strategy;

        public int Atack() => _atackStrategy.CalculateDamage( _totalStrength );

        public int GetCurrentHealth() => _currentHealth;

        public int GetMaxHealth() => _maxHealth;

        public int TakeDamage( int damage )
        {
            int realDamage = Math.Max( damage - _totalArmor, 0 );
            _currentHealth = Math.Max( 0, _currentHealth - realDamage );
            return realDamage;
        }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Health: {_currentHealth}/{_maxHealth}\n" +
                $"Strength: {_totalStrength}\n" +
                $"Armor: {_totalArmor}\n" +
                $"Initiative: {Initiative}\n" +
                $"Race: {_race.GetType().Name}\n" +
                $"Class: {_class.GetType().Name}\n" +
                $"Weapon: {_weapon.GetType().Name}\n" +
                $"ArmorType: {_armor.GetType().Name}\n" +
                $"Status: {( IsAlive ? "Alive" : "Dead" )}\n";
        }
    }
}