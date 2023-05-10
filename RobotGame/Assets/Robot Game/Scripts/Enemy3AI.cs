using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3AI : MonoBehaviour
{
    public GameObject RightPos;
    public GameObject LeftPos;
    private float RightOriginal;
    private float LeftOriginal;
 // private float Horizontal = 5f;
    private Vector2 moveForce;
 //   private bool Switch = true;
    // Start is called before the first frame update


    // Reference to the rigidbody component of the object
    private Rigidbody2D rb;

    // The speed at which the object moves horizontally
    public float moveSpeed = 5f;

    // The minimum and maximum x-coordinates the object can move between
    

    // The direction the object is currently moving in (1 = right, -1 = left)
    private int moveDirection = 1;

    // Start is called before the first frame update
    void Start()
    {
        LeftOriginal = LeftPos.transform.position.x;
        RightOriginal = RightPos.transform.position.x;
        // Get the Rigidbody2D component of the object
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        // Calculate the new position of the object based on its current position and the move speed
        Vector2 newPosition = rb.position + new Vector2(moveSpeed * moveDirection * Time.deltaTime, 0);

        // Check if the new position is within the allowed range
        if (newPosition.x < LeftOriginal && moveDirection == -1)
        {
            // If the new position is below the minimum x-coordinate, change the direction to right
            moveDirection = 1;
        }
        else if (newPosition.x > RightOriginal && moveDirection == 1)
        {
            // If the new position is above the maximum x-coordinate, change the direction to left
            moveDirection = -1;
        }

        if (newPosition.x < RightOriginal)
        {
            gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

        }

        // Set the new position of the object
        rb.MovePosition(newPosition);
    }
    
}
