using UnityEngine;

public class JumpState : IPlayerState
{
  
    public void EnterState(PlayerController player)
    {
        // Initialize jump animation
        player.SetAnimation("Jump");
        player.rb.velocity = new Vector2(player.rb.velocity.x, player.jumpForce);
        Debug.Log("isGrounded: " + player.isGrounded);
        
    }

    public void UpdateState(PlayerController player)
    {
        if (player.isGrounded)
        {
            Debug.Log("landed");
            player.TransitionToState(new IdleState());
            player.SetAnimation("IdleAfterJump");
        }   
    }

    public void ExitState(PlayerController player)
    {
    }
}
