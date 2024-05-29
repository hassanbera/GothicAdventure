using UnityEngine;

public class JumpState : IPlayerState
{
  
    public void EnterState(PlayerController player)
    {
        // Initialize jump animation
        player.rb.velocity = new Vector2(player.rb.velocity.x, player.jumpForce);
        Debug.Log("isGrounded: " + player.isGrounded);
        
    }

    public void UpdateState(PlayerController player)
    {
        if (player.isGrounded)
        {
            player.TransitionToState(new IdleState());
        }
    }

    public void ExitState(PlayerController player)
    {
    }
}
