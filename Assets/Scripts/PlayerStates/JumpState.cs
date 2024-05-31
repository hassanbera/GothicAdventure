using UnityEngine;

public class JumpState : IPlayerState
{

    public void EnterState(PlayerController player)
    {
        // Initialize jump animation
        player.rb.velocity = new Vector2(player.rb.velocity.x, player.JumpForce);
        Debug.Log("isGrounded: " + player.isGrounded);

    }

    public void UpdateState(PlayerController player)
    {
        if (player.isGrounded)
        {
            player.TransitionToState(new IdleState());
        }

        // if he moves 
        if(Input.GetAxis("Horizontal") != 0)
        {
            player.TransitionToState(new RunningState());
        }
    }

    public void ExitState(PlayerController player)
    {
    }
}
