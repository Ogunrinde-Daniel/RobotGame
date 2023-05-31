using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{

    public float slowDownFactor = 0.05f;
    public bool falling = false;
    private SoundManager soundManager;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(falling)return;
        if (collision.CompareTag("Saw") || collision.CompareTag("FallLegs"))
            return;
        falling = true;
        playSound();
        var camera = FindObjectOfType<CinemachineVirtualCamera>();
        camera.GetCinemachineComponent<CinemachineTransposer>().m_YDamping = 0;
        camera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y = -5;

        Debug.Log("Fall activated");
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    void playSound()
    {
        if (soundManager == null)
            return;

        soundManager.playBGMusic(0);
    }

}
