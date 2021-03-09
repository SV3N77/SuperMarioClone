using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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
        restartGame();
        exitGame();
    }

    public void loadGameOver()
    {
        SceneManager.LoadScene(1);
        Invoke("loadGameScene", 4.0f);
    }

    public void loadGameScene()
    {
        SceneManager.LoadScene(0);
    }

    void restartGame()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    void exitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
