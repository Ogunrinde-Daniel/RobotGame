using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaMenuScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 OriginalPosition;
    // Start is called before the first frame update
    void Start()
    {
        OriginalPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x <= 12f)
        {
            rb.velocity = new Vector3(1, 0, 0);

        }
        else if(gameObject.transform.position.x >= 12f)
        {
            gameObject.transform.position = new Vector3(OriginalPosition.x - 6, OriginalPosition.y, OriginalPosition.z);
        }
    }
}
