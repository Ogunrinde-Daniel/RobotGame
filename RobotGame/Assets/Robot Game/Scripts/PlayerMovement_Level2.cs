using UnityEngine;

public class PlayerMovement_Level2 : MonoBehaviour
{
    //Objects
    public GameObject head;
    public GameObject legs;

    private Rigidbody2D rb;
    [SerializeField] private Animator legAnimator;
    [SerializeField] private IsGrounded isGrounded;

    //Input
    private float dirX;
    private bool jump;
    private bool isMoving;

    //movement paramters
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    
    //hover effect
    private Vector2 headOffset;
    [SerializeField]private float idleAmplitude = 0.01f;
    [SerializeField]private float idleFrequency = 3.5f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        headOffset = head.transform.localPosition;
    }

    void Update()
    {
        //get horizontal axis-- arrow keys/AD
        dirX = Input.GetAxisRaw("Horizontal");

        isMoving = (dirX != 0);

        if (isMoving){
            var scale = transform.localScale;
            scale.x = dirX * Mathf.Abs(scale.x);
            transform.localScale = scale;

        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded.is_Grounded)
        {
            jump = true;
        }

        //leg animator
        if (isGrounded.is_Grounded){
            legAnimator.SetBool("Walk", isMoving);
        }else{
            legAnimator.SetBool("Walk", false);
        }

    }

    void FixedUpdate()
    {

        rb.velocity = new Vector2(speed * dirX * Time.deltaTime, rb.velocity.y);
        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jump = false;
        }

        if (!isMoving)
        {
            // Add idle hovering
            float idleOffset = Mathf.Sin(Time.time * idleFrequency) * idleAmplitude;
            headOffset.y += idleOffset;

        }
        head.transform.localPosition = headOffset;
    }
}
