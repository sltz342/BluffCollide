using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessGameManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        RunGame();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RunGame()
    {
        for (int i = 0; i < 4; i++)
        {
            if (MinigameManager.players[i] != null)
            {
                Debug.Log("There is " + MinigameManager.PlayerAmount + " players");
                Debug.Log(MinigameManager.players[i] + " is playing");
            }
            
        }
    }
}
