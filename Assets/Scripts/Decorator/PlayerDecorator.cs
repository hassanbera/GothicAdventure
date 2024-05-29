public abstract class PlayerDecorator : IPlayer
{
    protected IPlayer decoratedPlayer;

    public PlayerDecorator(IPlayer player)
    {
        decoratedPlayer = player;
    }

    public virtual int JumpForce
    {
        get => decoratedPlayer.JumpForce;
        set => decoratedPlayer.JumpForce = value;
    }
    public virtual float Speed
    {
        get => decoratedPlayer.Speed;
        set => decoratedPlayer.Speed = value;
    }
    public virtual float Attack
    {
        get => decoratedPlayer.Attack;
        set => decoratedPlayer.Attack = value;
    }

    public virtual void ApplyBoost()
    {
        decoratedPlayer.ApplyBoost();
    }
}
