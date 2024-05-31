using UnityEngine;
public class AttackingState : IPlayerState
{
    public void EnterState(PlayerController player)
    {
        // Initialize idle animation
        
        player.animator.SetFloat("speed", 0);
        player.animator.SetBool("attack", true);
    }

    public void UpdateState(PlayerController player)
    {
       if(Input.GetButtonUp("Fire1"))
        {
            player.animator.SetBool("attack", false);
            player.TransitionToState(new IdleState());
        }
        
    }

    public void ExitState(PlayerController player)
    {
        // Cleanup if necessary
    }
}