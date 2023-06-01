using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    private int switchCounter = 0;
    private bool CounterSwitch = false;
    private Rigidbody2D rb;
    private int Speed = 5;
    private Vector3 OriginalScale;
    public Color AttackColor;
    private Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
        OriginalScale = gameObject.transform.localScale;
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if(CounterSwitch == false)
        {
            rb.velocity = new Vector3(-Speed, 0, 0);

        }
        else if(CounterSwitch == true)
        {
            rb.velocity = new Vector3(Speed, 0, 0);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = AttackColor;
        }

        if(collision.collider.tag == "Tile")
        {
            switchCounter++;
            if(switchCounter % 2 != 0)
            {
                CounterSwitch = true;
                gameObject.transform.localScale = new Vector3(-OriginalScale.x, OriginalScale.y, OriginalScale.z);
                

            }
            else if(switchCounter % 2 == 0)
            {
                CounterSwitch = false;
                gameObject.transform.localScale = new Vector3(OriginalScale.x, OriginalScale.y, OriginalScale.z);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = originalColor;
        }
    }
}
