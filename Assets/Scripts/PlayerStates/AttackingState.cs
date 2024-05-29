using UnityEngine;
public class AttackingState : IPlayerState
{
    public void EnterState(PlayerStateController player)
    {
        // Initialize idle animation
        player.SetAnimation("Idle");
    }

    public void UpdateState(PlayerStateController player)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.TransitionToState(new JumpState());
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            player.TransitionToState(new RunningState());
        }
    }

    public void ExitState(PlayerStateController player)
    {
        // Cleanup if necessary
    }
}
