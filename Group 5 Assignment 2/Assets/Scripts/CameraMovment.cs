using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    [SerializeField]
    private Transform mario;

    private float xPosMemory = -2.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(mario.position.x, xPosMemory, 46.0f), 1.0f, -10.0f);
        xPosMemory = transform.position.x;
    }
}
