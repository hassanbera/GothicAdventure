using UnityEngine;

public class RunningState : IPlayerState
{
    public void EnterState(PlayerController player)
    {
        // Initialize idle animation
        player.rb.velocity = new Vector2(player.Speed * Input.GetAxis("Horizontal"), player.rb.velocity.y);
    }

    public void UpdateState(PlayerController player)
    {
        if (Input.GetKeyDown(KeyCode.Space) && player.isGrounded)
        {
            player.TransitionToState(new JumpState());
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            player.TransitionToState(new RunningState());
            if (Input.GetAxis("Horizontal") > 0)
            {
                player.spriteRenderer.flipX = false;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                player.spriteRenderer.flipX = true;
            }

        }

        else if (Input.GetAxis("Horizontal") == 0)
        {
            player.TransitionToState(new IdleState());
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Attacking");
            player.TransitionToState(new AttackingState());
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Attacking2");
            player.TransitionToState(new AttackingState2());
        }
    }

    public void ExitState(PlayerController player)
    {
        // Cleanup if necessary
    }
}
