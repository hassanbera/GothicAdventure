using UnityEngine;
public class GameController : MonoBehaviour
{
    private IPlayer player;

    void Start()
    {
        player = new Player();


    }
}
