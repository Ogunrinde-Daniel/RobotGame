using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegColliderInFall : MonoBehaviour
{
    Fall fall;
    void Start()
    {
        fall = FindObjectOfType<Fall>();
    }

    void Update()
    {
        if (fall != null && fall.falling)
        {
            GetComponent<Rigidbody2D>().gravityScale = -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Destroy(gameObject);
    }
}
