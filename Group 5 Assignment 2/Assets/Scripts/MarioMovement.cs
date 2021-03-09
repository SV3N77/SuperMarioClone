using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovement : MonoBehaviour
{
    //These are the fields that can be controled by designer
    [Header("Movement Setting")]
    [Tooltip("The maximum X velocity of Mario")]
    [SerializeField]
    private float maxSpeed = 10.0f;
    [Tooltip("The Additional value of Max Speed when running")]
    [SerializeField]
    private float runMaxSpeed = 2.0f;
    [Tooltip("The acceleration per second of Mario")]
    [SerializeField]
    private float acceleration = 9.8f;
    [Tooltip("The Addition value of acceleration when running")]
    [SerializeField]
    private float runAcceleration = 2.2f;
    [Tooltip("The deceleration per second when Mario stop runing but still walking to the same direction")]
    [SerializeField]
    private float autoDeceleration = 7.0f;
    [Tooltip("The deceleration per second of Mario toward the inertial velocity When turning i.e. The acceleration toward the inputed direction which is opposite from the inertial velocity")]
    [SerializeField]
    private float turningAcceleration = 15.0f;
    [Tooltip("The deceleration per second of Mario when there is no left or right input")]
    [SerializeField]
    private float deceleration = 5.0f;

    [Header("Jumping Setting")]
    [Tooltip("The acceleration (units / second) at time = 0 in jump")]
    [SerializeField]
    private float jumpAcceleration = 10.0f;
    [Tooltip("The increased value per second in Mario's gravity scale when falling (If no change to the gravity scale, change to 0.0f)")]
    [SerializeField]
    private float jumpDeceleration = 1.0f;
    [Tooltip("The maximun gravity scale when Mario is falling")]
    [SerializeField]
    private float jumpMaxDeceleration = 2.0f;
    [Tooltip("The additional upward acceleration of Mario walk jump(Levelone jump) (Additional to stand jump(Levelzero jump))")]
    [SerializeField]
    private float levelOneJumpAcceleration = 1.0f;
    [Tooltip("The additional upward acceleration of Mario run jump(Leveltwo jump) (Additional to stand jump(Levelzero jump))")]
    [SerializeField]
    private float levelTwoJumpAcceleration = 3.0f;
    [Tooltip("The upper limit of Mario X velocity that he will perform a stand jump(Levelzero jump)")]
    [SerializeField]
    private float levelZeroJumpBoundary = 1.0f;
    [Tooltip("The upper limit of Mario x velocity that he will perform a walk jump(Levelone jump). Also, while Mario x velocity > levelOneJumpBoundary, he will perform a run jump(Leveltwo jump)")]
    [SerializeField]
    private float levelOneJumpBoundary = 10.0f;

    [Header("Components")]
    [Tooltip("The Rigidbody2D Componenet of Mario")]
    [SerializeField]
    private Rigidbody2D marioRig;
    [SerializeField]
    private AnimationManager animMan;

    //These fields are used for code and calculation
    private bool onGround = false;

    private void Awake()
    {
        if (marioRig == null)
            marioRig = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        marioFalling();

        //testing code
        //if (Input.GetAxisRaw("Horizontal") != 0.0f)
        //{
        //    marioMovement(Input.GetAxisRaw("Horizontal"), Input.GetKey(KeyCode.L));
        //} else
        //{
        //    marioDecelering();
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("DeathPlane"))
        {
            MarioDie();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //code for testing
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    marioJump();
        //}
    }

    public void marioMovement(float dir, bool isRun)
    {
        float acc = (isRun) ? acceleration + runAcceleration : acceleration;
        float max = (isRun) ? maxSpeed + runMaxSpeed : maxSpeed;

        if (0.0f <= dir * marioRig.velocity.x) 
        {
            if (Mathf.Abs(marioRig.velocity.x) > maxSpeed && !isRun)
            {
                //AutoDecelerate
                marioRig.velocity = new Vector2(Mathf.Clamp(marioRig.velocity.x, -1.0f, 1.0f) * Mathf.Clamp(Mathf.Abs(marioRig.velocity.x) - autoDeceleration * Time.fixedDeltaTime, maxSpeed, runMaxSpeed + maxSpeed), marioRig.velocity.y);
            } else
            {
                //Normal Accelerate
                marioRig.velocity = new Vector2(Mathf.Clamp(marioRig.velocity.x + dir * acc * Time.fixedDeltaTime, -max, max), marioRig.velocity.y); 
            }
        } else
        {
            //Turning Accelerate
            marioRig.velocity = new Vector2(marioRig.velocity.x + dir * turningAcceleration * Time.fixedDeltaTime, marioRig.velocity.y);
        }

    }

    public void marioDecelering()
    {
        if (Mathf.Abs(marioRig.velocity.x) <= deceleration)
        {
            marioRig.velocity = new Vector2(0.0f, marioRig.velocity.y);
        } else {
            float antiDir = -marioRig.velocity.x / Mathf.Abs(marioRig.velocity.x);
            marioRig.velocity = new Vector2(marioRig.velocity.x + antiDir * deceleration * Time.fixedDeltaTime, marioRig.velocity.y);
        }
    }

    public void marioJump()
    {
        if (onGround)
        {
            marioRig.velocity += Vector2.up * (jumpAcceleration + levelOfJump());
            onGround = false;
        }
    }

    public void marioFalling()
    {
        if (!onGround)
        {
            marioRig.gravityScale = Mathf.Clamp(marioRig.gravityScale + jumpDeceleration * Time.fixedDeltaTime, 1.0f, jumpMaxDeceleration);
        }
    }

    public void resetMarioGravityScale()
    {
        marioRig.gravityScale = 1.0f;
    }

    private float levelOfJump()
    {
        float vel = Mathf.Abs(marioRig.velocity.x);
        if (vel <= levelZeroJumpBoundary)
        {
            return 0.0f;
        }
        else if (vel < levelOneJumpBoundary)
        {
            return levelOneJumpAcceleration;
        }
        else
        {
            return levelTwoJumpAcceleration;
        }
    }

    private void MarioDie()
    {
        marioRig.GetComponent<CapsuleCollider2D>().enabled = false;
        marioRig.velocity = Vector2.up * 1.5f * jumpAcceleration;
        animMan.MarioDie();
    }

    public void setOnGround(bool isGrounded)
    {
        onGround = isGrounded;
        if (isGrounded)
        {
            animMan.GroundTrigger();
        }
    }

    public float getMarioYVelocity()
    {
        return marioRig.velocity.y;
    }

    public bool getOnground()
    {
        return onGround;
    }

    public float getMatioVelocity()
    {
        return marioRig.velocity.x;
    }
}
