using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConstantValues
{
    public static int MoneyToGetPastGo = 100;
    public static int RandomPositionCard()
    {
        return Random.Range(1, 11);
    }
}

public enum GameStates
{
    // This specifies wether its the bidding phase, move around the board phase, or a minigame
    // phase + what minigame is playing
    Board,
    Bidding,
    Minigame
}