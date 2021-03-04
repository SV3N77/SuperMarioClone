using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovement : MonoBehaviour
{
    [Header("Movement Setting")]
    [Tooltip("The maximum X velocity of Mario")]
    [SerializeField]
    private float maxSpeed = 10.0f;
    [Tooltip("The Addition value of Max Speed when running")]
    [SerializeField]
    private float runMaxSpeed = 2.0f;
    [Tooltip("The acceleration per Fixedframes of Mario")]
    [SerializeField]
    private float acceleration = 0.2f;
    [Tooltip("The Addition value of acceleration when running")]
    [SerializeField]
    private float runAcceleration = 0.05f;
    [Tooltip("The deceleration when Mario stop runing but still walking to the same direction")]
    [SerializeField]
    private float autoDeceleration = 0.05f;
    [Tooltip("The deceleration of Mario toward the inertial velocity When turning i.e. The acceleration toward the inputed direction which is opposite from the inertial velocity")]
    [SerializeField]
    private float turningAcceleration = 0.3f;
    [Tooltip("The deceleration of Mario when there is no left or right input")]
    [SerializeField]
    private float deceleration = 0.15f;

    [Header("Jumping Setting")]
    [SerializeField]
    private float jumpVelocity;
    [SerializeField]
    private float jumpDeceleration;

    [Header("Components")]
    [Tooltip("The Rigidbody2D Componenet of Mario")]
    [SerializeField]
    private Rigidbody2D marioRig;


    private void Awake()
    {
        marioRig = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0.0f)
        {
            marioMovement(Input.GetAxisRaw("Horizontal"), Input.GetKey(KeyCode.L));
        } else
        {
            marioDecelering();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
                marioRig.velocity = new Vector2(Mathf.Clamp(marioRig.velocity.x, -1.0f, 1.0f) * Mathf.Clamp(Mathf.Abs(marioRig.velocity.x) - autoDeceleration, maxSpeed, runMaxSpeed + maxSpeed), marioRig.velocity.y);
            } else
            {
                //Normal Accelerate
                marioRig.velocity = new Vector2(Mathf.Clamp(marioRig.velocity.x + dir * acc, -max, max), marioRig.velocity.y); 
            }
        } else
        {
            //Turning Accelerate
            marioRig.velocity = new Vector2(marioRig.velocity.x + dir * turningAcceleration, marioRig.velocity.y);
        }

    }

    public void marioDecelering()
    {
        if (Mathf.Abs(marioRig.velocity.x) <= deceleration)
        {
            marioRig.velocity = new Vector2(0.0f, marioRig.velocity.y);
        } else {
            float antiDir = -marioRig.velocity.x / Mathf.Abs(marioRig.velocity.x);
            marioRig.velocity = new Vector2(marioRig.velocity.x + antiDir * deceleration, marioRig.velocity.y);
        }
    }
}
