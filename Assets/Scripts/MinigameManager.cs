using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    public static string[] players = new string[4];
    public int miniGameNumber = 1;
    public static int PlayerAmount = 0;

    [SerializeField] private GameManager manager;

    public void Start()
    {
        StartMiniGame();
    }
    void StartMiniGame()
    {
        if (manager.Player_One.IsPlayingMinigame == true)
        {
            players[PlayerAmount] = "player 1";
            PlayerAmount++;
        }
        if (manager.Player_Two.IsPlayingMinigame == true)
        {
            players[PlayerAmount] = "player 2";
            PlayerAmount++;
        }
        if (manager.Player_Three.IsPlayingMinigame == true)
        {
            players[PlayerAmount] = "player 3";
            PlayerAmount++;
        }
        if (manager.Player_Four.IsPlayingMinigame == true)
        {
            players[PlayerAmount] = "player 4";
            PlayerAmount++;
        }
        //players.Add("Player 1");
        //players.Add("Player 2");

        SceneManager.LoadScene("MiniGame" + miniGameNumber);
    }
}
