using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartCollision : MonoBehaviour
{
    public int damage = 100;
    public int timeIncrease = 5;
    public bool isWeakPoint = false;
    public GameObject parentGameObject;
    public ParticleSystem robotDead;
    public Transform particleHolder;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isWeakPoint && parentGameObject != null)
            {
                collision.gameObject.GetComponent<Player>().increaseTime(timeIncrease);

                Destroy(parentGameObject,0.5f);
                var _particle = Instantiate(robotDead, particleHolder.position, Quaternion.identity);
                //_particle.transform.parent = particleHolder.transform;
                //parentGameObject.SetActive(false);
                var sprites = parentGameObject.GetComponentsInChildren<SpriteRenderer>();
                for (int i = 0; i < sprites.Length; i++)
                {
                    sprites[i].enabled = false;
                }
                foreach (MonoBehaviour script in parentGameObject.GetComponents<MonoBehaviour>())
                {
                    script.enabled = false;
                }

            }
            else
            {
                collision.gameObject.GetComponent<Player>().dealDamage(damage);
                parentGameObject.GetComponent<EnemyMovement>().turnOffRobot();
                //parentGameObject.GetComponent<EnemyMovement>().enabled = false;
            }


        }

    }
}
