using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoredPlayerInformation
{
    [Header("Token")]
    public Transform PlayerToken;
    public Vector3 TokenOffset;

    [Header("Basic Values")]
    public int OnSpot = 1;
    public int CurrentShares = 0;
    public int TotalMoney = 500;

    public bool HasRolledThisTurn = false;
    public bool IsPlayingMinigame = false;
    public int CurrentBidAmount = 0;
}