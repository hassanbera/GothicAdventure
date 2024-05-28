public abstract class PlayerDecorator : IPlayer
{
    protected IPlayer decoratedPlayer;

    public PlayerDecorator(IPlayer player)
    {
        decoratedPlayer = player;
    }

    public virtual int Health
    {
        get => decoratedPlayer.Health;
        set => decoratedPlayer.Health = value;
    }
    public virtual int Attack
    {
        get => decoratedPlayer.Attack;
        set => decoratedPlayer.Attack = value;
    }
    public virtual int Speed
    {
        get => decoratedPlayer.Speed;
        set => decoratedPlayer.Speed = value;
    }


    public virtual void ApplyBoost()
    {
        decoratedPlayer.ApplyBoost();
    }
}
