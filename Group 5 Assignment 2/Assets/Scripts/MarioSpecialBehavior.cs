using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioSpecialBehavior : MonoBehaviour
{
    [SerializeField]
    private float spawnDistance = 0.55f;
    [SerializeField]
    private GameObject fireballPrefab;
    [SerializeField]
    private InteractionManager inactMan;

    //testing code
    //private float dirMemory = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Items"))
        {
            //Gets GameManager.CollectType of the item (Or the items Call this)
            inactMan.marioCollectItem(GameManager.CollectType.Coin); //get the collecttype from above
        }
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
