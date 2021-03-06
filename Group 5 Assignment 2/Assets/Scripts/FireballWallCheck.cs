using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballWallCheck : MonoBehaviour
{
    [SerializeField]
    private FireBall fireball;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("map")) 
        {
            fireball.flip();
        }
    }

    private void FixedUpdate()
    {
        wallCheckMovement();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void wallCheckMovement()
    {
        transform.position = new Vector2(fireball.getDir() * fireball.getEdge() + fireball.transform.position.x, fireball.getEdge() + fireball.transform.position.y);
        transform.rotation = Quaternion.identity;
    }
}
