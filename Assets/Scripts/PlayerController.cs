using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private IPlayerState currentState;

    void Start()
    {
        TransitionToState(new IdleState());
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void TransitionToState(IPlayerState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState(this);
        }
        currentState = newState;
        newState.EnterState(this);
    }

    public void SetAnimation(string animationName)
    {
        // Implement animation change logic here
    }
}
