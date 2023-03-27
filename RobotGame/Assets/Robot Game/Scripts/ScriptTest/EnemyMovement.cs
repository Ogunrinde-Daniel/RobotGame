using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]private GameObject Wheel;
    private Transform wheelTransform;
    //private float originalPositionOnTile;
    private bool Switch = false;
    private bool Begin = false;
    private float RestingYPos;
    [SerializeField]private GameObject leftBorder;
    [SerializeField]private GameObject rightBorder;
    [SerializeField] private float speed = 5;
    private float leftBorderPos;
    private float rightBorderPos;    

    // Start is called before the first frame update
    void Start()
    {
        leftBorderPos = leftBorder.transform.position.x;
        rightBorderPos = rightBorder.transform.position.x;
        wheelTransform = Wheel.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Begin == true)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, RestingYPos, gameObject.transform.position.z);
            wheelTransform.Rotate(0,0,5 * Time.deltaTime);
        }

    }

    private void FixedUpdate()
    {
        if (Begin == true)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, RestingYPos, gameObject.transform.position.z);
            //    wheelTransform.Rotate(0,0,5 * Time.deltaTime);

            if (!Switch)
            {
                if (gameObject.transform.position.x <= rightBorderPos)
                {
                    gameObject.transform.position += new Vector3(Random.Range(speed - 3, speed) * Time.deltaTime, 0, 0);
                }

                if (gameObject.transform.position.x >= rightBorderPos)
                {
                    gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, -gameObject.transform.localScale.z);
                    Switch = true;
                }
            }

            else
            {
                if (gameObject.transform.position.x >= leftBorderPos)
                {
                    gameObject.transform.position -= new Vector3(Random.Range(speed - 3, speed) * Time.deltaTime, 0, 0);

                }

                if (gameObject.transform.position.x <= leftBorderPos)
                {
                    gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, -gameObject.transform.localScale.z);
                    Switch = false;
                }
            }
        }
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Tile")
        {
            Invoke("BeginMovement", 2f);
            
        }
    }

    private void BeginMovement()
    {
        Begin = true;
        RestingYPos = gameObject.transform.position.y - (-0.45f);
        Wheel.SetActive(true);
    }
}
