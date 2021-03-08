using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void marioCollectItem(CollectType type)
    {
        switch(type) 
        {
            case CollectType.Coin:
                marioCoin();
                break;
            case CollectType.OneUp:
                marioOneUp();
                break;
            case CollectType.Star:
                marioStar();
                break;
            case CollectType.Mushroom:
                marioMushroom();
                break;
            case CollectType.FireFlower:
                marioFireFlower();
                break;
        }
    }

    private void marioCoin()
    {
        //coinCount++;   Wherever this is
        //sound
    }

    private void marioOneUp()
    {
        //MarioLive++; Wherever this is
        //Show 1-up
        //sound
    }

    private void marioStar()
    {
        //change some state
        //animation
        //music
    }

    private void marioMushroom()
    {
        if (GameManager.instance.marioState == MarioState.Small) 
        {
            GameManager.instance.marioState = MarioState.Large;
            //animation
        }
            //sound
    }

    private void marioFireFlower()
    {
        if (GameManager.instance.marioState != MarioState.FireFlower) 
        {
            //change mariostate
            //animation
        }
            //sound
    }
}
