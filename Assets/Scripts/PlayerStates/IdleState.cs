using UnityEngine;
public class IdleState : IPlayerState
{
    public void EnterState(PlayerController player)
    {
        // Initialize idle animation
        player.SetAnimation("Idle");
    }

    public void UpdateState(PlayerController player)
    {
        if (Input.GetKeyDown(KeyCode.Space) && player.isGrounded)
        {
            player.isGrounded = false;
            player.TransitionToState(new JumpState());
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            player.TransitionToState(new RunningState());
        }
    }

    public void ExitState(PlayerController player)
    {
        // Cleanup if necessary
    }
}

// Similar implementations for RunState and JumpState...
