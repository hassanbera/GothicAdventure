public class GameController : MonoBehaviour
{
    private IPlayer player;

    void Start()
    {
        player = new Player();

        // Apply health boost
        player = new HealthBoost(player);
        player.ApplyBoost();

        // Apply shield boost
        player = new ShieldBoost(player);
        player.ApplyBoost();
    }
}
