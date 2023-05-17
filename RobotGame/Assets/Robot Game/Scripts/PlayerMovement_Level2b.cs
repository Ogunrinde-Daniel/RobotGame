using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Level2b : MonoBehaviour
{
    //movement paramters
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    public GameObject legs;
    public GameObject head;

    private Rigidbody2D rb;
    private Vector2 headOffset;
    public float headJumpOffset;


    [SerializeField] private IsGrounded isGrounded;
    //Input
    private float dirX;
    private bool jump;
    private bool isMoving;
    public bool falling = false;
    public bool checkFalling = false;

    //hover effect
    [SerializeField]private float idleAmplitude = 0.01f;
    [SerializeField]private float idleFrequency = 3.5f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        headOffset = head.transform.localPosition;
        headJumpOffset = 0f;
        jump = true;
    }

    void Update()
    {
        //get horizontal axis-- arrow keys/AD
        dirX = Input.GetAxis("Horizontal");

        if (dirX == 0){isMoving = false;}
        else{isMoving = true;}

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded.is_Grounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {

        rb.velocity = new Vector2(speed * dirX * Time.deltaTime, rb.velocity.y);
        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jump = false;
            checkFalling = true;
        }

        if (rb.velocity.y != 0)
        {
            headJumpOffset = 1;
        }

        if (falling && rb.velocity.y == 0)
        {
            falling = false;
            headJumpOffset = -1;
        }

        if (rb.velocity.y == 0 && isGrounded.is_Grounded && checkFalling)
        {
            falling = true;
            checkFalling = false;
        }


        if (!isMoving)
        {
            // Add idle hovering
            float idleOffset = Mathf.Sin(Time.time * idleFrequency) * idleAmplitude;
            headOffset.y += idleOffset;
        }

        var newPos = headOffset + new Vector2(0, headJumpOffset);
        if (newPos.y < 0)
        {
            newPos = new Vector2(0, 0);
            headJumpOffset = 0; 
        }
        newPos.y = Mathf.Lerp(head.transform.localPosition.y, newPos.y, 0.25f);
        head.transform.localPosition = newPos;
    }
}
