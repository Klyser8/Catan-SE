using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public int playerCount = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < playerCount; i++)
        {
            var player = new GameObject();
            player.name = "Player " + (i + 1);
            player.AddComponent<PlayerController>();
        }
    }
}
