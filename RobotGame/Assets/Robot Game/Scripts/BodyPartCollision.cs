using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartCollision : MonoBehaviour
{
    public bool isWeakPoint = false;
    public GameObject parentGameObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isWeakPoint && parentGameObject != null)
            {
                parentGameObject.SetActive(false);
            }
            else
            {
                collision.gameObject.SetActive(false);
                parentGameObject.GetComponent<EnemyMovement>().enabled = false;
            }


        }

    }
}
