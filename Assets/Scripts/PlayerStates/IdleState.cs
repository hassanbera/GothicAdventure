using UnityEngine;
public class IdleState : IPlayerState
{
    public void EnterState(PlayerController player)
    {
        // Initialize idle animation
    }

    public void UpdateState(PlayerController player)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.TransitionToState(new JumpState());
        }

        else if (Input.GetAxis("Horizontal") != 0)
        {
            player.TransitionToState(new RunningState());
        }

        else if(Input.GetButtonDown("Fire1"))
        {
            player.TransitionToState(new AttackingState());
            
        }

        else if(Input.GetButtonDown("Fire2"))
        {
            player.TransitionToState(new AttackingState2());
        }
        

    }

    public void ExitState(PlayerController player)
    {
        // Cleanup if necessary
    }
}

// Similar implementations for RunState and JumpState...
