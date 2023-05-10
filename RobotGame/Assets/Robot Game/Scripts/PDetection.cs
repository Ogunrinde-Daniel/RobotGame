using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDetection : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GetComponentInParent<EMovement>() != null)
        {
            GetComponentInParent<EMovement>().BeginPatrol();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GetComponentInParent<EMovement>() != null)
        {
            GetComponentInParent<EMovement>().EndPatrol();
        }
    }
}
