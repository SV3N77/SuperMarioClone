using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioSpecialBehavior : MonoBehaviour
{
    [SerializeField]
    private float spawnDistance = 0.55f;
    [SerializeField]
    private GameObject fireballPrefab;

    //testing code
    //private float dirMemory = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //testing code
        //if (Input.GetAxisRaw("Horizontal") != 0.0f) {
        //    dirMemory = Input.GetAxisRaw("Horizontal");
        //}
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    firesFireBalls(dirMemory);
        //}
    }

    public void firesFireBalls(float dir)
    {
        FireBall fireball = Instantiate(fireballPrefab, transform.position + Vector3.right * dir * spawnDistance, Quaternion.identity).GetComponent<FireBall>();
        if (dir < 0.0f && fireball != null)
        {
            fireball.flip();
        }
    }

    public void ducking()
    {

    }
}
