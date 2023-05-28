using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public float levelDuration = 30f; // Duration of the level in seconds

    public float timeLeft; // Remaining time in seconds

    public bool isGameOver = false; // Flag to track if the game is over

    private DialogueManager dialogueManager;
    private void Start()
    {
        timeLeft = levelDuration; // Initialize the remaining time
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            // Update the timer
            if(!dialogueManager.dialogueOn)
                timeLeft -= Time.deltaTime;

            // Check if the timer has reached zero
            if (timeLeft <= 0f)
            {
                GameOver();
            }
        }
    }

    public void AddTime(float time)
    {
        timeLeft += time; // Add the specified time to the remaining time
    }

    private void GameOver()
    {
        isGameOver = true;
        // Perform any game over logic here, such as showing a game over screen or ending the level.
        Debug.Log("Game Over");
    }

    public void DisplayTime(float timeToDisplay, TextMeshProUGUI timeText, Color textColor)
    {
        //one second error for countdowns
        timeToDisplay += 1;
        //minute and seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        //text display
        timeText.color = textColor;
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
