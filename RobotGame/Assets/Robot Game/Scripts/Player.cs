using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private AudioSource drop;

    private bool playerDead = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (playerDead)
            return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Saw")
        {
            playerDead = true;
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "RobotEnemy")
        {
            playerDead = true;
            this.enabled = false;
        }
        if (collision.gameObject.tag == "RobotWeakPoint")
        {
            collision.gameObject.GetComponent<Robot>().enabled = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            drop.Play();
        }

    }
}
