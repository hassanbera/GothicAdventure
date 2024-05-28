public interface IPlayer
{
    int Health { get; set; }
    int Attack { get; set; }
    int Speed { get; set; }
    void ApplyBoost();
}
