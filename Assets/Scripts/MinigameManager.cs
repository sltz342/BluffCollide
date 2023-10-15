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
        //StartMiniGame();
    }

    private void Update()
    {
        if (SceneManager.loadedSceneCount == 1)
        {
            EndMinigame();
        }
    }
    public void StartMiniGame()
    {
        ResetArray();
        if (manager.Player_One.IsPlayingMinigame == true)
        {
            players[PlayerAmount] = "Player_One";
            PlayerAmount++;
        }
        if (manager.Player_Two.IsPlayingMinigame == true)
        {
            players[PlayerAmount] = "Player_Two";
            PlayerAmount++;
        }
        if (manager.Player_Three.IsPlayingMinigame == true)
        {
            players[PlayerAmount] = "Player_Three";
            PlayerAmount++;
        }
        if (manager.Player_Four.IsPlayingMinigame == true)
        {
            players[PlayerAmount] = "Player_four";
            PlayerAmount++;
        }
        

        SceneManager.LoadScene("MiniGame" + miniGameNumber, LoadSceneMode.Additive);
    }

    public void ResetArray()
    {
        for (int i = 0; i < 4; i++)
        {
            players[i] = null;
        }
        PlayerAmount = 0;
    }

    public static void CollectValuesMiniGame1()
    {
        Debug.Log("Working");
    }

    void EndMinigame()
    {
        GameManager manager = FindObjectOfType<GameManager>();
        if (manager.CurrentGameState == GameStates.Minigame)
        {
            manager.CurrentGameState = GameStates.Board;
        }
    }
}
