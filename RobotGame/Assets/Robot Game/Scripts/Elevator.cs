using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform endPoint;
    private Vector3 endPointPosition;
    private bool elevating;
    public float Speed =  10;
    void Start()
    {
        endPointPosition = endPoint.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (elevating)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPointPosition, Speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            elevating = true;
        }
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            elevating = true;
        }

    }*/

}
