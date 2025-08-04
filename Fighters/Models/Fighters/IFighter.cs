namespace Fighters.Models.Fighters
{
    public interface IFighter
    {
        string Name { get; }
        public int GetCurrentHealth();
        public int GetMaxHealth();
        public int Attack();
        public int TakeDamage( int damage );
        public bool IsAlive { get; }
    }
}
