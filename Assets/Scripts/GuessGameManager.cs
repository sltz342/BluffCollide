using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GuessGameManager : MonoBehaviour
{
    public int playerCount = 0;
    public string[] players = new string[4];
    public int[] Guesses = new int[4];
    int ranNum;
    int guessNum = 0;
    public TMP_Text GameText;
    public TMP_InputField Guess;
    public int product;
    bool OnePlayer = false;
    bool TwoPlayer = false;
    bool ThreePlayer = false;
    bool FourPlayer = false;

    [SerializeField] private MinigameManager mManager;

    public static bool Player1Won = false;
    public static bool Player2Won = false;
    public static bool Player3Won = false;
    public static bool Player4Won = false;

    public static int WinPrize = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetValues();
        if (playerCount == 1)
        {
            RunGame1P();
        }
        if (playerCount == 2)
        {
            RunGame2P();
        }
        if (playerCount == 3)
        {
            RunGame3P();
        }
        if (playerCount == 4)
        {
            RunGame4P();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void SetValues()
    {
        mManager = FindObjectOfType<MinigameManager>();

        Player1Won = false;
        Player2Won = false;
        Player3Won = false;
        Player4Won = false;
        playerCount = MinigameManager.PlayerAmount;
        
        for (int i = 0; i < 4; i++)
        {
            players[i] = MinigameManager.players[i];
        }
    }

    void RunGame1P()
    {
        OnePlayer = true;
        ranNum = Random.Range(1, 20);
        GameText.text = players[0] + " guess a number between 1 and 20";

    }
    void RunGame2P()
    {
        TwoPlayer = true;
        ranNum = Random.Range(1, 20);
        GameText.text = players[0] + " guess a number between 1 and 20";

    }
    void RunGame3P()
    {
        ThreePlayer = true;
        ranNum = Random.Range(1, 20);
        GameText.text = players[0] + " guess a number between 1 and 20";

    }
    void RunGame4P()
    {
        FourPlayer = true;
        ranNum = Random.Range(1, 20);
        GameText.text = players[0] + " guess a number between 1 and 20";

    }


    public void GuessEnter()
    {

        if (OnePlayer == true) 
        {
            if (guessNum == 1)
            {
                mManager.CollectValuesMiniGame1();
                SceneManager.UnloadSceneAsync("MiniGame1");
            }
            product = ranNum - int.Parse(Guess.text);

            guessNum = guessNum + 1;

            if (product == 0)
            {
                GameText.text = "Correct, you win 250. The answer was " + ranNum + ".";
                Player1Won = true;
                WinPrize = 250;
            }
            if (product == 1 || product == -1)
            {
                GameText.text = "1 off, you win 150. The answer was " + ranNum + ".";
                Player1Won = true;
                WinPrize = 150;
            }
            if (product == 2 || product == -2)
            {
                GameText.text = "2 off, you win 100. The answer was " + ranNum + ".";
                Player1Won = true;
                WinPrize = 100;
            }
            if (product > 2 || product < -2)
            {
                GameText.text = "Too far off, you win nothing. The answer was " + ranNum + ".";
            }
        }
        
        if (TwoPlayer == true)
        {
            if (guessNum == 2)
            {
                mManager.CollectValuesMiniGame1();
                SceneManager.UnloadSceneAsync("MiniGame1");
            }

            product = ranNum - int.Parse(Guess.text);

            Guesses[guessNum] = Mathf.Abs(product);

            
            Guess.text = null;

            guessNum = guessNum + 1;
            GameText.text = players[guessNum] + " guess a number between 1 and 20";

            if (guessNum == 2)
            {
                if (Guesses[0] == Guesses[1])
                {
                    GameText.text = "The answer was " + ranNum + ", you tied, " + players[0] + " and " + players[1] + " get 125.";
                    Player1Won = true;
                    Player2Won = true;
                    WinPrize = 125;
                }
                if (Guesses[0] < Guesses[1])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[0] + " wins 250";
                    Player1Won = true;
                    WinPrize = 250;
                }
                if (Guesses[0] > Guesses[1])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[1] + " wins 250";
                    Player2Won = true;
                    WinPrize = 250;
                }
            }
        }

        if (ThreePlayer == true)
        {
            if (guessNum == 3)
            {
                mManager.CollectValuesMiniGame1();
                SceneManager.UnloadSceneAsync("MiniGame1");
            }

            product = ranNum - int.Parse(Guess.text);

            Guesses[guessNum] = Mathf.Abs(product);

            
            Guess.text = null;

            guessNum = guessNum + 1;
            GameText.text = players[guessNum] + " guess a number between 1 and 20";

            if (guessNum == 3)
            {
                
                if (Guesses[0] == Guesses[1] && Guesses[0] == Guesses[2])
                {
                    GameText.text = "The answer was " + ranNum + ", you tied, " + players[0] + ", " + players[1] + " and " + players[2] + " get 75 each.";
                    Player1Won = true;
                    Player2Won = true;
                    Player3Won = true;
                    WinPrize = 75;
                }
                if (Guesses[0] == Guesses[1] && Guesses[0] < Guesses[2])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[0] + " and " + players[1] + " tied and win 125 each.";
                    Player1Won = true;
                    Player2Won = true;
                    WinPrize = 125;
                }
                if (Guesses[0] == Guesses[2] && Guesses[0] < Guesses[1])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[0] + " and " + players[2] + " tied and win 125 each.";
                    Player1Won = true;
                    Player3Won = true;
                    WinPrize = 125;
                }
                if (Guesses[1] == Guesses[2] && Guesses[1] < Guesses[0])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[1] + " and " + players[2] + " tied and win 125 each.";
                    Player2Won = true;
                    Player3Won = true;
                    WinPrize = 125;
                }
                if (Guesses[0] < Guesses[1] && Guesses[0] < Guesses[2])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[0] + " wins 250";
                    Player1Won = true;
                    WinPrize = 250;
                }
                if (Guesses[1] < Guesses[0] && Guesses[1] < Guesses[2])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[1] + " wins 250";
                    Player2Won = true;
                    WinPrize = 250;
                }
                if (Guesses[2] < Guesses[1] && Guesses[2] < Guesses[0])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[2] + " wins 250";
                    Player3Won = true;
                    WinPrize = 250;
                }
            }
        }
        if (FourPlayer == true)
        {
            if (guessNum == 4)
            {
                mManager.CollectValuesMiniGame1();
                SceneManager.UnloadSceneAsync("MiniGame1");
            }

            product = ranNum - int.Parse(Guess.text);

            Guesses[guessNum] = Mathf.Abs(product);


            Guess.text = null;

            guessNum = guessNum + 1;
            if (guessNum < 4)
            {
                GameText.text = players[guessNum] + " guess a number between 1 and 20";
            }
            

            if (guessNum == 4)
            {

                if (Guesses[0] == Guesses[1] && Guesses[0] == Guesses[2] && Guesses[0] == Guesses[3])
                {
                    GameText.text = "The answer was " + ranNum + ", you tied, " + players[0] + ", " + players[1] + ", " + players[2] + " and " + players[3] + " get 50 each.";
                    Player1Won = true;
                    Player2Won = true;
                    Player3Won = true;
                    Player4Won = true;
                    WinPrize = 50;
                }
                if (Guesses[0] == Guesses[1] && Guesses[0] == Guesses[2] && Guesses[0] < Guesses[3])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[0] + ", " + players[1] + " and " + players[2] + " tied and win 75 each.";
                    Player1Won = true;
                    Player2Won = true;
                    Player3Won = true;
                    WinPrize = 75;
                }
                if (Guesses[0] == Guesses[2] && Guesses[0] == Guesses[3] && Guesses[0] < Guesses[1])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[0] + ", " + players[2] + " and " + players[3] + " tied and win 75 each.";
                    Player1Won = true;
                    Player3Won = true;
                    Player4Won = true;
                    WinPrize = 75;
                }
                if (Guesses[0] == Guesses[1] && Guesses[0] == Guesses[3] && Guesses[0] < Guesses[2])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[0] + ", " + players[1] + " and " + players[3] + " tied and win 75 each.";
                    Player1Won = true;
                    Player2Won = true;
                    Player4Won = true;
                    WinPrize = 75;
                }
                if (Guesses[1] == Guesses[2] && Guesses[1] == Guesses[3] && Guesses[1] < Guesses[0])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[1] + ", " + players[2] + " and " + players[3] + " tied and win 75 each.";
                    Player2Won = true;
                    Player3Won = true;
                    Player4Won = true;
                    WinPrize = 75;
                }
                if (Guesses[0] == Guesses[1] && Guesses[0] < Guesses[2] && Guesses[0] < Guesses[3])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[0] + " and " + players[1] + " tied and win 125 each.";
                    Player1Won = true;
                    Player2Won = true;
                    WinPrize = 125;
                }
                if (Guesses[0] == Guesses[2] && Guesses[0] < Guesses[1] && Guesses[0] < Guesses[3])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[0] + " and " + players[2] + " tied and win 125 each.";
                    Player1Won = true;
                    Player3Won = true;
                    WinPrize = 125;
                }
                if (Guesses[0] == Guesses[3] && Guesses[0] < Guesses[1] && Guesses[0] < Guesses[2])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[0] + " and " + players[3] + " tied and win 125 each.";
                    Player1Won = true;
                    Player4Won = true;
                    WinPrize = 125;
                }
                if (Guesses[1] == Guesses[2] && Guesses[1] < Guesses[0] && Guesses[1] < Guesses[3])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[1] + " and " + players[2] + " tied and win 125 each.";
                    Player2Won = true;
                    Player3Won = true;
                    WinPrize = 125;
                }
                if (Guesses[1] == Guesses[3] && Guesses[1] < Guesses[0] && Guesses[1] < Guesses[2])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[1] + " and " + players[3] + " tied and win 125 each.";
                    Player2Won = true;
                    Player4Won = true;
                    WinPrize = 125;
                }
                if (Guesses[2] == Guesses[3] && Guesses[2] < Guesses[0] && Guesses[2] < Guesses[1])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[2] + " and " + players[3] + " tied and win 125 each.";
                    Player3Won = true;
                    Player4Won = true;
                    WinPrize = 125;
                }
                if (Guesses[0] < Guesses[1] && Guesses[0] < Guesses[2] && Guesses[0] < Guesses[3])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[0] + " wins 250";
                    Player1Won = true;
                    WinPrize = 250;
                }
                if (Guesses[1] < Guesses[0] && Guesses[1] < Guesses[2] && Guesses[1] < Guesses[3])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[1] + " wins 250";
                    Player2Won = true;
                    WinPrize = 250;
                }
                if (Guesses[2] < Guesses[0] && Guesses[2] < Guesses[1] && Guesses[2] < Guesses[3])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[2] + " wins 250";
                    Player3Won = true;
                    WinPrize = 250;
                }
                if (Guesses[3] < Guesses[0] && Guesses[3] < Guesses[1] && Guesses[3] < Guesses[2])
                {
                    GameText.text = "The answer was " + ranNum + ", " + players[3] + " wins 250";
                    Player4Won = true;
                    WinPrize = 250;
                }
            }
        }
    }
}
