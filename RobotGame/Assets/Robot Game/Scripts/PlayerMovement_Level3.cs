using UnityEngine;

public class PlayerMovement_Level3 : MonoBehaviour
{
    //Objects
    public GameObject head;
    public GameObject body;
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
    private Vector2 bodyOffset;
    [SerializeField]private float idleAmplitude = 0.01f;
    [SerializeField]private float idleFrequency = 3.5f;


    private TouchManager touchManager;
    private SoundManager soundManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        headOffset = head.transform.localPosition;
        bodyOffset = body.transform.localPosition;

        touchManager = FindObjectOfType<TouchManager>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        //get horizontal axis-- arrow keys/AD
        if (Application.isMobilePlatform)
            dirX = touchManager.getXAxis();  //I add .5 to the speed to counter the slow movement
        else
            dirX = Input.GetAxisRaw("Horizontal");

        isMoving = (dirX != 0);

        if (isMoving){
            var scale = transform.localScale;
            scale.x = dirX * Mathf.Abs(scale.x);
            transform.localScale = scale;

        }
        if ((Input.GetKeyDown(KeyCode.Space) || touchManager.getJump()) && isGrounded.is_Grounded)
        {
            touchManager.setJump(false);
            jump = true;
            soundManager.playSfx(SoundManager.SFX_TYPES.jumpMoveSfx);
        }

        //leg animator
        if (isGrounded.is_Grounded){
            legAnimator.SetBool("Walk", isMoving);
        }else{
            legAnimator.SetBool("Walk", false);
        }
        soundManager.playWalkLoop(legAnimator.GetBool("Walk"));


    }

    void FixedUpdate()
    {

        rb.velocity = new Vector2(speed * dirX * Time.deltaTime, rb.velocity.y);
        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jump = false;
        }

        Vector2 tempHeadOffset = headOffset;
        Vector2 tempBodyOffset = bodyOffset;
        if (!isMoving)
        {
            // Add idle hovering
            float idleOffset = Mathf.Sin(Time.time * idleFrequency) * idleAmplitude;
            tempHeadOffset = headOffset + new Vector2(0,idleOffset/2);
            tempBodyOffset = bodyOffset + new Vector2(0, idleOffset);
        }

        head.transform.localPosition = tempHeadOffset;
        body.transform.localPosition = tempBodyOffset;
    }
}
