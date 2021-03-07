using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public MarioState marioState = MarioState.Small; // Default state: small. 

    void Awake() // Makes sure there's only one GameManager
    {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        
    }
}
