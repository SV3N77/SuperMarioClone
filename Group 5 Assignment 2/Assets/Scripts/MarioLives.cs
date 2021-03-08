using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarioLives : MonoBehaviour
{
    private float TotalLives = 1; // Total time of level
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Mario" + "\n" + TotalLives.ToString("000000");
    }
}
