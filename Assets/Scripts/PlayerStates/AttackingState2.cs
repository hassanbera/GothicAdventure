using UnityEngine;
public class AttackingState2 : IPlayerState
{
    public void EnterState(PlayerController player)
    {
        // Initialize idle animation
        
        player.animator.SetFloat("speed", 0);
        player.animator.SetBool("attack", false);
        player.animator.SetBool("attack2", true);
    }

    public void UpdateState(PlayerController player)
    {
       if(Input.GetButtonUp("Fire2"))
        {
            player.animator.SetBool("attack2", false);
            player.TransitionToState(new IdleState());
        }
        
    }

    public void ExitState(PlayerController player)
    {
        // Cleanup if necessary
    }
}
