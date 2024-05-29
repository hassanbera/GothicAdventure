using UnityEngine;

public class RunningState : IPlayerState
{
    public void EnterState(PlayerController player)
    {
        // Initialize idle animation
        player.SetAnimation("Run");
        player.rb.velocity = new Vector2(player.speed * Input.GetAxis("Horizontal"), player.rb.velocity.y);
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
            if(Input.GetAxis("Horizontal") > 0)
            {
                player.spriteRenderer.flipX = false;
            }
            else if(Input.GetAxis("Horizontal") < 0)
            {
                player.spriteRenderer.flipX = true;
            }
            
        }
    }

    public void ExitState(PlayerController player)
    {
        // Cleanup if necessary
    }
}
