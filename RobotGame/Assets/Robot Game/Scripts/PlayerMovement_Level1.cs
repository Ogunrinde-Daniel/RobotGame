using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Level1 : MonoBehaviour
{
    //movement paramters
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotateSpeed;

    [SerializeField] private IsGrounded isGrounded;
    [SerializeField] private LayerMask groundLayerMask;

    private TouchManager touchManager;
    private SoundManager soundManager;
    private Fall fall;



    //Input
    private float dirX;
    private bool jump;
    private bool isMoving;

    private Rigidbody2D rb;
    private Rotation rotation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rotation = gameObject.AddComponent<Rotation>();
        rotation.speed = 0;

        touchManager = FindObjectOfType<TouchManager>();
        soundManager = FindObjectOfType<SoundManager>();
        fall = FindObjectOfType<Fall>();

    }


    void Update()
    {
        if (fall != null)
        {
            if (fall.falling)
                speed = Mathf.Min(speed * 30, 8000);

        }


        //get horizontal axis-- arrow keys/AD
        if (Application.isMobilePlatform)
            dirX = touchManager.getXAxis() * 1.2f;  //I add .5 to the speed to counter the slow movement
        else
            dirX = Input.GetAxis("Horizontal");


        if ((Input.GetKeyDown(KeyCode.Space) || touchManager.getJump()) && isGrounded.is_Grounded)
        {
            touchManager.setJump(false);
            jump = true;
            soundManager.playSfx(SoundManager.SFX_TYPES.jumpMoveSfx);
        }


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (speed * dirX * Time.deltaTime, rb.velocity.y);
        rotation.speed = rotateSpeed * -dirX;
        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jump = false;
        }
    }

   

}
