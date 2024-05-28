public class JumpState : IPlayerState
{
    public void EnterState(PlayerController player)
    {
        // Initialize idle animation
        player.SetAnimation("Idle");
    }

    public void UpdateState(PlayerController player)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.TransitionToState(new JumpState());
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            player.TransitionToState(new RunState());
        }
    }

    public void ExitState(PlayerController player)
    {
        // Cleanup if necessary
    }
}
