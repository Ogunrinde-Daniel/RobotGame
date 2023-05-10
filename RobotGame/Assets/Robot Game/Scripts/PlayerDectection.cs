using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDectection : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player") || collision.CompareTag("PlayerLeg")) && GetComponentInParent<EnemyMovement>() != null)
        {
            GetComponentInParent<EnemyMovement>().BeginPatrol();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GetComponentInParent<EnemyMovement>() != null)
        {
            GetComponentInParent<EnemyMovement>().EndPatrol();
        }
    }
}
