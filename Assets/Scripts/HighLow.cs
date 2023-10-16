using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighLow : MonoBehaviour
{
    public int currentCard;
    public static int guessesGiven = 0;
    private MinigameManager mManager;
    public static string[] players = new string[4];
    public static bool[] playersGuess = new bool[4];
    public static bool[] playersWon = new bool[4];

    
    [SerializeField] public Button highButton;
    [SerializeField] public Button lowButton;
    [SerializeField] public Button finishGame;
    [SerializeField] public TMP_Text dealerCard;
    [SerializeField] public TMP_Text playerWhich;
    
    // Start is called before the first frame update
    void Start()
    {
        SetValues();
        
    }

    public void SetValues()
    {
        mManager = FindObjectOfType<MinigameManager>();
        for (int i = 0; i < 4; i++)
        {
            players[i] = MinigameManager.players[i];
            playersWon[i] = false;
        }

        guessesGiven = 0;
        currentCard = DealNewCard();
        switch(currentCard) 
        {
            case 11:
                dealerCard.text += "Jack";
                break;
            case 12:
                dealerCard.text += "Queen";
                break;
            case 13:
                dealerCard.text += "King";
                break;
            default:
                dealerCard.text += currentCard;
                break;
        }
        
        
        playerWhich.text = "Guess High or Low! Player 1";
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public int DealNewCard()
    {
        int newCard = (Random.Range(0, 12) + 1);
        return newCard;
    }

    public void highButtonClicked()
    {
        playersGuess[guessesGiven] = true;
        guessesGiven++;
        if (guessesGiven == 4)
        {
            CheckWinConditions();
        }
        else
        {
            playerWhich.text = "Guess High or Low! Player " + (guessesGiven + 1);
        }
    }
    
    public void lowButtonClicked()
    {
        playersGuess[guessesGiven] = false;
        guessesGiven++;
        if (guessesGiven == 4)
        {
            CheckWinConditions();
        }
        else
        {
            playerWhich.text = "Guess High or Low! Player " + (guessesGiven+1);
        }
    }

    public void CheckWinConditions()
    {
        int newCard = DealNewCard();
        int difference = currentCard - newCard;
        bool didCardWin;
        
        if (difference > 0)
        {
            didCardWin = true;
        } else if (difference < 0)
        {
            didCardWin = false;
        }
        else
        {
            didCardWin = false;
        }

        string newText = "";
        
        for (int i = 0; i < 4; i++)
        {
            if (playersGuess[i] == didCardWin)
            {
                playersWon[i] = true;
                newText += "Player " + (i+1) + ", ";
            }
        }

        newText += "guessed correctly!";

        playerWhich.text = newText;
        finishGame.interactable = true;
        highButton.interactable = false;
        lowButton.interactable = false;
    }

    public void finishButtonClicked()
    {
        FinishMinigame();
    }

    public void FinishMinigame()
    {
        mManager.CollectValuesMiniGame2(playersWon[0],playersWon[1],playersWon[2],playersWon[3], 250);
        SceneManager.UnloadSceneAsync("MiniGame2");
    }


}
