using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    //fields controled by designer
    [Header("Fireball Setting")]
    [Tooltip("The horizontal velocity (unit / second) of the fireball")]
    [SerializeField]
    private float horizontalSpeed = 14.0f;
    [Tooltip("The maximum vertical distance the fireball will get from the floor that it just bounced off (The C in [Ax^2 + C])")]
    [SerializeField]
    private float bounceHeight = 0.8f;
    [Tooltip("Larger slopeDeceleration cause flatter curve, vice versus. The inverted A in [Ax^2 + C]. NOTE: [slopeDeceleration > 0] !!!!!!!!")]
    [SerializeField]
    private float slopeDeceleration = 10.0f;
    [SerializeField]
    private float raycastLength = 0.1f;
    [SerializeField]
    private float lifeTime = 5.0f;
    [SerializeField]
    private float animationSpeed = 1.5f;
    [SerializeField]
    private string groundTag = "map";

    //component fields
    [Header("Components of Fireball")]
    [SerializeField]
    private Animation anim;
    [SerializeField]
    private SpriteRenderer spriteRend;
    [SerializeField]
    private Rigidbody2D rig;

    //codeing and calculation fields
    private float dir = 1.0f;
    private float realA;
    private float initSlope;
    private float slope;
    private float ddydxx;
    private float edge;

    private void Awake()
    {
        setupFields();
        if (anim == null)
            anim = GetComponent<Animation>();
        if (spriteRend == null)
            spriteRend = GetComponent<SpriteRenderer>();
        if (rig == null)
            rig = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        anim["FireballSpining"].speed *= animationSpeed;
        selfDestruct();
    }

    private void FixedUpdate()
    {
        fireballMovement();
        //raycastCheck();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(groundTag)) 
        {
                bounceOffGround();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void flip()
    {
        spriteRend.flipX = true;
        dir *= -1.0f;
        anim["FireballSpining"].speed *= -1.0f;
    }

    private void fireballMovement()
    {
        rig.MovePosition(new Vector2(rig.position.x + horizontalSpeed * Time.fixedDeltaTime * dir, rig.position.y + horizontalSpeed * Time.fixedDeltaTime * slope));
        slope += ddydxx * horizontalSpeed * Time.fixedDeltaTime;
    }

    private void bounceOffGround()
    {
        slope = initSlope;
    }

    private void raycastCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * dir, edge + raycastLength);
        Debug.DrawRay(transform.position, Vector2.right * dir, Color.blue);
        if (hit.transform.tag.Equals(groundTag))
        {
        Debug.Log("Raycast Hit a map");
            flip();
        }
    }

    private void setupFields()
    {
        realA = 1.0f / slopeDeceleration;
        float xIntercept = Mathf.Sqrt(bounceHeight / realA);
        initSlope = dir * 2 * realA * xIntercept;
        slope = dir * -2 * realA * xIntercept / 2;
        ddydxx = dir * -2 * realA;
        edge = 0.004f * transform.localScale.x;
    }

    private void selfDestruct()
    {
        Destroy(gameObject, lifeTime);
    }

    public float getEdge()
    {
        return edge;
    }

    public float getDir()
    {
        return dir;
    }
}
