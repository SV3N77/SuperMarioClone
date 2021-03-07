using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    static public int marioLives = 3;
    static public MarioState marioState = MarioState.Small; // Default state: small. 

    public enum MarioState
    {
        Small,
        Large,
        FireFlower,
        SuperStar
    }

    public enum CollectType
    {
        Coin,
        One_Up,
        Mushroom,
        FireFlower,
        SuperStar
    }
}
