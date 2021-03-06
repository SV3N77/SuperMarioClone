using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioOnGround : MonoBehaviour
{
    [SerializeField]
    private MarioMovement movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("map"))   
        {
            movement.setOnGround(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("map"))
        {
            movement.setOnGround(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
