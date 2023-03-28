using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Level1 : MonoBehaviour
{
    //movement paramters
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotateSpeed;

    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private IsGrounded isGrounded;

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
    }


    void Update()
    {
        //get horizontal axis-- arrow keys/AD
        dirX = Input.GetAxis("Horizontal");
       
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded.is_Grounded)
        {
            jump = true;
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
