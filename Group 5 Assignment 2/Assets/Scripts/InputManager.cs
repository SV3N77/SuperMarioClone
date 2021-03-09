using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private MarioMovement marioMove;
    [SerializeField]
    private MarioSpecialBehavior marioSpecial;
    [SerializeField]
    private AnimationManager animMan;
    [SerializeField]
    private SpriteRenderer marioRend;

    private float dirMemory = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0.0f)
        {
            dirMemory = Input.GetAxisRaw("Horizontal");
            marioMove.marioMovement(Input.GetAxisRaw("Horizontal"), Input.GetButton("Run"));
            marioRend.flipX = dirMemory < 0;
        } else
        {
            marioMove.marioDecelering();
        }

        if (Input.GetAxisRaw("Vertical") < 0.0f)
        {
            marioSpecial.ducking();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            animMan.jumpTrigger();
            marioMove.marioJump();
        }

        if (Input.GetButtonDown("Run"))
        {
            marioSpecial.firesFireBalls(dirMemory);
        }
    }


}
