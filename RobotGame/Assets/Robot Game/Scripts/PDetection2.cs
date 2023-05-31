using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDetection2 : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GetComponentInParent<E2Movement>() != null)
        {
            GetComponentInParent<E2Movement>().BeginPatrol();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GetComponentInParent<E2Movement>() != null)
        {
            GetComponentInParent<E2Movement>().EndPatrol();
        }
    }
}
