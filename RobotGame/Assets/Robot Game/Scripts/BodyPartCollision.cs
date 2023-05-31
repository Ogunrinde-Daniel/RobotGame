using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class BodyPartCollision : MonoBehaviour
{
    public int damage = 100;
    public int timeIncrease = 5;
    public bool isWeakPoint = false;
    public GameObject parentGameObject;
    public ParticleSystem robotDead;
    public Transform particleHolder;

    private static bool isdead = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isWeakPoint && parentGameObject != null)
            {
                isdead = true;
                collision.gameObject.GetComponent<Player>().increaseTime(timeIncrease);

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
                Destroy(parentGameObject);

            }
            else
            {
                if(isdead) return;
                collision.gameObject.GetComponent<Player>().dealDamage(damage);
                parentGameObject.GetComponent<EnemyMovement>().turnOffRobot();
                //parentGameObject.GetComponent<EnemyMovement>().enabled = false;
            }


        }

    }

    private void OnDestroy()
    {
        isdead = false;
    }
}
