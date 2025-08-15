using Fighters.AttackStrategy;
using Fighters.Models.Armors;
using Fighters.Models.Classes;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters
{
    public interface IFighter
    {
        string Name { get; }
        int Initiative { get; }
        bool IsAlive { get; }
        IArmor Armor { get; }
        IWeapon Weapon { get; }
        IRace Race { get; }
        IClass Class { get; }
        public void SetAttackStrategy( IAttackStrategy strategy );
        public int GetCurrentHealth();
        public int GetMaxHealth();
        public int Attack();
        public void ReduceHealth( int amount );
        public void Heal( int healAmount );
        public int TakeDamage( int damage );
        public void HealFull();
        public IClass GetClass();
    }
}
