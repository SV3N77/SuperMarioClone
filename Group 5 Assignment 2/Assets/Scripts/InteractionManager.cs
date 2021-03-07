using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private int coinNum = 0;
    public int CoinNum { get; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void marioCollectItem(GameManager.CollectType type)
    {
        switch(type)
        {
            case GameManager.CollectType.Coin:
                marioGetsCoin();
                break;
            case GameManager.CollectType.One_Up:
                marioGetsOneUp();
                break;
            case GameManager.CollectType.SuperStar:
                marioGetsSuperStar();
                break;
            case GameManager.CollectType.Mushroom:
                marioGetsMushroom();
                break;
            case GameManager.CollectType.FireFlower:
                marioGetsFireFlower();
                break;
            default:
                Debug.LogError("What The Hell Did Mario Just Eat?????????");
                break;
        }
    }

    private void marioGetsCoin()
    {
        coinNum++;
        //sound
        //update GUI
    }

    private void marioGetsOneUp()
    {
        GameManager.marioLives++;
        //sound
        //show 1-up
    }

    private void marioGetsSuperStar()
    {
        //Change mario state
        //update animation
        //change music
        //Invoke change back
    }

    private void marioGetsMushroom()
    {
        //change mario state
        //sound
        //update animation
        //if anything else like change collier size and stuff
    }

    private void marioGetsFireFlower()
    {
        //change mario state
        //sound
        //update animation
    }
}
