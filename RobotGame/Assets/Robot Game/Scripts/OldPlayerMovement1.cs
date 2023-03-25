using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayerMovement1 : MonoBehaviour
{
    //movement paramters
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float accelerationSpeed;
    [SerializeField] private float deccelerationSpeed;


    //Input
    private int dirX;
    private bool jump;
    private bool isMoving;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        //get horizontal axis-- arrow keys/AD
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            dirX = -1;
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            dirX = 1;
            isMoving = true;
        }
        else
        {
            dirX = 0;
            isMoving = false;
        }
        if (Input.GetKeyDown(KeyCode.Space)) jump = true;

    }

    private void FixedUpdate()
    {
        
        if (isMoving){ //accelerate
            currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, accelerationSpeed * Time.deltaTime);
        }
        else{ //decelerate
            currentSpeed = Mathf.Lerp(currentSpeed, 0f, deccelerationSpeed * Time.deltaTime);
            if(currentSpeed < 0.001) currentSpeed = 0f;
        }

        rb.AddForce(new Vector2(currentSpeed * dirX, 0));
        //rb.velocity = new Vector2(currentSpeed * dirX, rb.velocity.y);

        if (jump)
        {
            rb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
            jump = false;
        }


    }


}
