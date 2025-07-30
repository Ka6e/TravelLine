namespace Fighters.Models.Fighters
{
    public interface IFighter
    {
        string Name { get; }
        public int GetCurrentHealth();
        public int GetMaxHealth();
        public int Attack();
        int TakeDamage( int damage );
        bool IsAlive { get; }
    }
}
