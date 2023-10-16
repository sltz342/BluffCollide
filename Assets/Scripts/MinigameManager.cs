using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    public static string[] players = new string[4];
    public int miniGameNumber = Random.Range(1, 2);
    public static int PlayerAmount = 0;

    [SerializeField] private GameManager manager;
    //bool Player1Won = false;
    //bool Player2Won = false;
    //bool Player3Won = false;
    //bool Player4Won = false;



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

    public void CollectValuesMiniGame1()
    {
        

        int WinPrize = GuessGameManager.WinPrize;
        if (GuessGameManager.Player1Won == true)
        {
            if (players[0] == "Player_One")
            {
                manager.Player_One.TotalMoney = manager.Player_One.TotalMoney + WinPrize;
            }
            if (players[0] == "Player_Two")
            {
                manager.Player_Two.TotalMoney = manager.Player_Two.TotalMoney + WinPrize;
            }
            if (players[0] =="Player_Three")
            {
                manager.Player_Three.TotalMoney = manager.Player_Three.TotalMoney + WinPrize;
            }
            if (players[0] == "Player_Four")
            {
                manager.Player_Four.TotalMoney = manager.Player_Four.TotalMoney + WinPrize;
            }
        }
        if (GuessGameManager.Player2Won == true)
        {
            if (players[1] == "Player_Two")
            {
                manager.Player_Two.TotalMoney = manager.Player_Two.TotalMoney + WinPrize;
            }
            if (players[1] == "Player_Three")
            {
                manager.Player_Three.TotalMoney = manager.Player_Three.TotalMoney + WinPrize;
            }
            if (players[1] == "Player_Four")
            {
                manager.Player_Four.TotalMoney = manager.Player_Four.TotalMoney + WinPrize;
            }
        }
        if (GuessGameManager.Player3Won == true)
        {
            if (players[2] == "Player_Three")
            {
                manager.Player_Three.TotalMoney = manager.Player_Three.TotalMoney + WinPrize;
            }
            if (players[2] == "Player_Four")
            {
                manager.Player_Four.TotalMoney = manager.Player_Four.TotalMoney + WinPrize;
            }
        }
        if (GuessGameManager.Player4Won == true)
        {
            manager.Player_Four.TotalMoney = manager.Player_Four.TotalMoney + WinPrize;
        }
    }
    
    
    
    void EndMinigame()
    {
        GameManager manager = FindObjectOfType<GameManager>();
        if (manager.CurrentGameState == GameStates.Minigame)
        {
            manager.CurrentGameState = GameStates.Board;
        }
    }

    public void CollectValuesMiniGame2(bool player1Won , bool player2Won ,bool player3Won , bool player4Won, int moneyWon)
    {
        if (player1Won  == true)
        {
            if (players[0] == "Player_One")
            {
                manager.Player_One.TotalMoney = manager.Player_One.TotalMoney + moneyWon;
            }
            if (players[0] == "Player_Two")
            {
                manager.Player_Two.TotalMoney = manager.Player_Two.TotalMoney + moneyWon;
            }
            if (players[0] =="Player_Three")
            {
                manager.Player_Three.TotalMoney = manager.Player_Three.TotalMoney + moneyWon;
            }
            if (players[0] == "Player_Four")
            {
                manager.Player_Four.TotalMoney = manager.Player_Four.TotalMoney + moneyWon;
            }
        }
        if (player2Won == true)
        {
            if (players[1] == "Player_Two")
            {
                manager.Player_Two.TotalMoney = manager.Player_Two.TotalMoney + moneyWon;
            }
            if (players[1] == "Player_Three")
            {
                manager.Player_Three.TotalMoney = manager.Player_Three.TotalMoney + moneyWon;
            }
            if (players[1] == "Player_Four")
            {
                manager.Player_Four.TotalMoney = manager.Player_Four.TotalMoney + moneyWon;
            }
        }
        if (player3Won == true)
        {
            if (players[2] == "Player_Three")
            {
                manager.Player_Three.TotalMoney = manager.Player_Three.TotalMoney + moneyWon;
            }
            if (players[2] == "Player_Four")
            {
                manager.Player_Four.TotalMoney = manager.Player_Four.TotalMoney + moneyWon;
            }
        }
        if (player4Won == true)
        {
            manager.Player_Four.TotalMoney = manager.Player_Four.TotalMoney + moneyWon;
        }
        
        
        
    }
}
