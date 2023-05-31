using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public GameObject endScreen;
    public LevelTimer levelTimer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        levelTimer = FindObjectOfType<LevelTimer>();
        levelTimer.puaseTime = true;
        endScreen.SetActive(true);
    }
}
