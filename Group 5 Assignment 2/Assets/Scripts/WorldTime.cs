using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WorldTime : MonoBehaviour
{
    private float totalTime = 400; // Total time of level
    private float calculatingTime;
    Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        calculatingTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        calculatingTime -= 1 * Time.deltaTime;
        text.text = "Time " + "\n "+ calculatingTime.ToString("000");
    }
}
