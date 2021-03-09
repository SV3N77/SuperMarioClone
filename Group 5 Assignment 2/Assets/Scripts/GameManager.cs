using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void loadGameOver()
    {
        SceneManager.LoadScene(1);
        Invoke("loadGameScene", 5.0f);
    }

    public void loadGameScene()
    {
        SceneManager.LoadScene(0);
    }
}
