using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] private int speed = 2;
    [SerializeField] private bool goingRight = false;
    [SerializeField] private Transform tempLeftborderPoint;
    [SerializeField] private Transform tempRightborderPoint;

    private Vector2 leftBorderPoint;
    private Vector2 rightBorderPoint;

    private void Start()
    {
        leftBorderPoint = tempLeftborderPoint.position;
        rightBorderPoint = tempRightborderPoint.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (goingRight && Vector2.Distance(transform.position, rightBorderPoint) < 0.1f)
        {
            goingRight = false;

        }
        else if(Vector2.Distance(transform.position, leftBorderPoint) < 0.1f)
        {
            goingRight = true;
        }

        if (goingRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, rightBorderPoint, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, leftBorderPoint, speed * Time.deltaTime);
        }



    }
}
