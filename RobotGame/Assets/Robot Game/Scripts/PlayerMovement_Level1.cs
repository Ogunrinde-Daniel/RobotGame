using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Level1 : MonoBehaviour
{
    //movement paramters
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    //Input
    private float dirX;
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
        dirX = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
            jump = true;

    }

    private void FixedUpdate()
    {

        rb.AddForce(new Vector2(speed * dirX, 0));

        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jump = false;
        }


    }

}
