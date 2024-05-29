using UnityEngine;
using System.Collections;
public interface IPlayer
{
    float Health { get; set; }
    int Attack { get; set; }
    int Speed { get; set; }
    void ApplyBoost();
}
