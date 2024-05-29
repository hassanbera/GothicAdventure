using UnityEngine;
using System.Collections;
public interface IPlayer
{
    float Speed { get; set; }
    int JumpForce { get; set; }
    float Attack { get; set; }

    void ApplyBoost();
}
