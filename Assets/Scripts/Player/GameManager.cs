using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Players")]
    [Range(1, 4)]
    public int CurrentTurn = 1;
    //This here is the player information. It stores every value relating to a player.
    public StoredPlayerInformation Player_One;
    public StoredPlayerInformation Player_Two;
    public StoredPlayerInformation Player_Three;
    public StoredPlayerInformation Player_Four;

    [Header("Refrences")]
    //Refrences the board script, not the sprite
    [SerializeField] private BoardManager Board;
    //This text box states which player is playing currently.
    [SerializeField] private TMP_Text PlayerNumberIndicatorBox;
    //This text box states the current players Bid amount.
    [SerializeField] private TMP_Text CurrentBidAmountBox;
    //UI that is only in the Bidding Phase
    [SerializeField] private GameObject BiddingOnlyUI;
    //UI that is only in the Board Phase
    [SerializeField] private GameObject BoardOnlyUI;

    [Header("States")]
    public GameStates CurrentGameState;
    private void Start()
    {
        //Sets the player tokens position to the start of the board.
        SetPlayerLocation(Player_One);
        SetPlayerLocation(Player_Two);
        SetPlayerLocation(Player_Three);
        SetPlayerLocation(Player_Four);
    }

    private void Update()
    {
        #region Delete After Prototyping
        /*
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MovePlayerSpaces(Player_One, 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MovePlayerSpaces(Player_Two, 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MovePlayerSpaces(Player_Three, 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            MovePlayerSpaces(Player_Four, 1);
        }
        */
        #endregion

        // Sets the text for the player box
        PlayerNumberIndicatorBox.text = ("Player " + CurrentTurn.ToString());
        #region Constant UI Showers Type Stuff

        if (CurrentTurn == 1)
        {
            CurrentBidAmountBox.text = "$" +Player_One.CurrentBidAmount.ToString();
        }

        if (CurrentTurn == 2)
        {
            CurrentBidAmountBox.text = "$" + Player_Two.CurrentBidAmount.ToString();
        }

        if (CurrentTurn == 3)
        {
            CurrentBidAmountBox.text = "$" + Player_Three.CurrentBidAmount.ToString();
        }

        if (CurrentTurn == 4)
        {
            CurrentBidAmountBox.text = "$" + Player_Four.CurrentBidAmount.ToString();
        }

        //Sets the specific UI to activate deppending on game state
        BiddingOnlyUI.SetActive(CurrentGameState == GameStates.Bidding);
        BoardOnlyUI.SetActive(CurrentGameState == GameStates.Board);
        #endregion
    }

    #region On Board Functions
    public void Input_NextTurn()
    {
        CurrentTurn++;
        if (CurrentTurn > 4)
        {
            CurrentTurn = 1;

            Player_One.HasRolledThisTurn = false;
            Player_Two.HasRolledThisTurn = false;
            Player_Three.HasRolledThisTurn = false;
            Player_Four.HasRolledThisTurn = false;
            if (CurrentGameState == GameStates.Bidding)
            {
                CheckWhoWonTheShares();
                CurrentGameState = GameStates.Board;
            }
        }
    }

    public void Input_MoveSpaces()
    {
        if (CurrentTurn == 1)
        {
            if (!Player_One.HasRolledThisTurn)
            {
                MovePlayerSpaces(Player_One, ConstantValues.RandomPositionCard());
                Player_One.HasRolledThisTurn = true;
            }
        }
        if (CurrentTurn == 2)
        {
            if (!Player_Two.HasRolledThisTurn)
            {
                MovePlayerSpaces(Player_Two, ConstantValues.RandomPositionCard());
                Player_Two.HasRolledThisTurn = true;
            }
        }
        if (CurrentTurn == 3)
        {
            if (!Player_Three.HasRolledThisTurn)
            {
                MovePlayerSpaces(Player_Three, ConstantValues.RandomPositionCard());
                Player_Three.HasRolledThisTurn = true;
            }
        }
        if (CurrentTurn == 4)
        {
            if (!Player_Four.HasRolledThisTurn)
            {
                MovePlayerSpaces(Player_Four, ConstantValues.RandomPositionCard());
                Player_Four.HasRolledThisTurn = true;
            }
        }
    }

    private void MovePlayerSpaces(StoredPlayerInformation player, int NumberOfSpaces)
    {
        player.OnSpot += NumberOfSpaces;
        if (player.OnSpot > Board.BoardSpaces.Length)
        {
            player.OnSpot = 1;
            player.TotalMoney += ConstantValues.MoneyToGetPastGo;
        }

        SetPlayerLocation(player);
    }

    private void SetPlayerLocation(StoredPlayerInformation player)
    {
        player.PlayerToken.position = Board.BoardSpaces[player.OnSpot -1] + player.TokenOffset;
    }
    #endregion

    #region Bidding Functions
    
    public void ChangeBidAmount(int amount)
    {
        if (CurrentTurn == 1)
        {
            if ((Player_One.CurrentBidAmount + amount) <= Player_One.TotalMoney)
            {
                if ((Player_One.CurrentBidAmount + amount) >= 0)
                {
                    Player_One.CurrentBidAmount += amount;
                }
            }
        }

        if (CurrentTurn == 2)
        {
            if ((Player_Two.CurrentBidAmount + amount) <= Player_Two.TotalMoney)
            {
                if ((Player_Two.CurrentBidAmount + amount) >= 0)
                {
                    Player_Two.CurrentBidAmount += amount;
                }
            }
        }

        if (CurrentTurn == 3)
        {
            if ((Player_Three.CurrentBidAmount + amount) <= Player_Three.TotalMoney)
            {
                if ((Player_Three.CurrentBidAmount + amount) >= 0)
                {
                    Player_Three.CurrentBidAmount += amount;
                }
            }
        }

        if (CurrentTurn == 4)
        {
            if ((Player_Four.CurrentBidAmount + amount) <= Player_Four.TotalMoney)
            {
                if ((Player_Four.CurrentBidAmount + amount) >= 0)
                {
                    Player_Four.CurrentBidAmount += amount;
                }
            }
        }
    }

    public void CheckWhoWonTheShares()
    {
        int PlayerWithMostMoney = 1;
        int CurrentBidAmmount = Player_One.CurrentBidAmount;

        if (Player_Two.CurrentBidAmount > CurrentBidAmmount)
        {
            PlayerWithMostMoney = 2;
            CurrentBidAmmount = Player_Two.CurrentBidAmount;
        }

        if (Player_Three.CurrentBidAmount > CurrentBidAmmount)
        {
            PlayerWithMostMoney = 3;
            CurrentBidAmmount = Player_Three.CurrentBidAmount;
        }

        if (Player_Two.CurrentBidAmount > CurrentBidAmmount)
        {
            PlayerWithMostMoney = 4;
            CurrentBidAmmount = Player_Four.CurrentBidAmount;
        }

        if (PlayerWithMostMoney == 1)
        {
            Player_One.CurrentShares++;
        }
        if (PlayerWithMostMoney == 2)
        {
            Player_Two.CurrentShares++;
        }
        if (PlayerWithMostMoney == 3)
        {
            Player_Three.CurrentShares++;
        }
        if (PlayerWithMostMoney == 4)
        {
            Player_Four.CurrentShares++;
        }
    }

    #endregion
}