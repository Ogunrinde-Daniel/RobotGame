using System;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioSource drop;
    [SerializeField] private ParticleSystem death;
    [SerializeField] private HealthBehaviour healthBar;
    private GameManager gameManager;

    private bool playerDead = false;
    private int health;
    private int maxHealth = 100;

    float timeElapsed;  //for fading


    private void Start()
    {
        health = maxHealth;
        healthBar.SetHealth(health, maxHealth);
        gameManager = FindObjectOfType<GameManager>();

    }

    void Update()
    {

        if (playerDead)
        {
            //fade the sprite
            if (timeElapsed < 0.2)
            {
                if (GetComponent<SpriteRenderer>() != null)
                {
                    var _color = GetComponent<SpriteRenderer>().color;
                    _color.a = Mathf.Lerp(1, 0, timeElapsed / 0.2f);
                    GetComponent<SpriteRenderer>().color = _color;
                    timeElapsed += Time.deltaTime;
                }
                else
                {//for players with multiple body parts
                    var sprites = GetComponentsInChildren<SpriteRenderer>();
                    for (int i = 0; i < sprites.Length; i++)
                    {
                        var _color = sprites[i].color;
                        _color.a = Mathf.Lerp(1, 0, timeElapsed / 0.2f);
                        sprites[i].color = _color;
                    }
                    timeElapsed += Time.deltaTime;

                }

            }
            else
            {
                gameManager.GameOver();
            }

            return;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Saw")
        {
            dealDamage(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
       
        if (collision.gameObject.tag == "Platform")
        {
            //drop.Play();
        }
    }

    public void increaseTime(int time)
    {
        gameManager.AddTime(time);
    }


    public void dealDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health, maxHealth);
        if (health <= 0)
        {
            playerDead = true;
            Instantiate(death, transform.position,Quaternion.identity);
            //disable all scripts apart from this
            MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                if (script == this)
                    continue;
                script.enabled = false;
            }
            Destroy(this.gameObject, 1.0f);
        }

    }

}
