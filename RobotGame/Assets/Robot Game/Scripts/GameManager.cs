using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject textPopUp;
    [SerializeField] public LevelTimer levelTimer;
    [SerializeField] private Canvas mainCanvas;


    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject timesUpEffect;
    [SerializeField] private Color timerTextColor;
    [SerializeField] private Color timerTextCloseColor;
    [SerializeField] private int levelTime;

    public bool gameOver = false;
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    void Update()
    {

        if(levelTimer.timeLeft <= 10)
            levelTimer.DisplayTime(levelTimer.timeLeft, timerText, timerTextCloseColor);
        else
            levelTimer.DisplayTime(levelTimer.timeLeft, timerText, timerTextColor);

        timesUpEffect.SetActive(levelTimer.timeLeft <= 10);
        if (levelTimer.isGameOver)
        {
            GameOver();
        }
    }

    public void AddTime(int time)
    {
        levelTimer.AddTime(time);
        var popUp = Instantiate(textPopUp);
        popUp.transform.SetParent(mainCanvas.transform, false);
        popUp.GetComponent<PopUpTextAnimation>().textComponent.text = "+" + time.ToString();  

    }


    public void GameOver()
    {
        gameOver = true;
        gameOverScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
