using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject textPopUp;
    [SerializeField] public LevelTimer levelTimer;
    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private GameObject player;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject timesUpEffect;
    [SerializeField] private Color timerTextColor;
    [SerializeField] private Color timerTextCloseColor;
    [SerializeField] private int levelTime;

    public bool gameOver = false;
    void Start()
    {
        Time.timeScale = 1.0f;
        Debug.Log("Start " + LastCheckPoint.checkPointPosition.x);
        if (LastCheckPoint.checkPointPosition != null)
        {
            player.transform.position = LastCheckPoint.checkPointPosition;
        }
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
            LastCheckPoint.checkPointPosition = new Vector3(float.NaN, float.NaN, float.NaN);
            GameOver();
            //this might have to be removed in the future
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    RestartGame();
                }
            }
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
        if (LastCheckPoint.checkPointPosition != null)
        {
            RestartGame();
            return;
        }

        gameOver = true;
        gameOverScreen.SetActive(true);
        var textList = FindObjectsOfType<PopUpTextAnimation>();
        if (textList.Length > 0)
        {
            foreach (var item in textList)
            {
                Destroy(item.gameObject);
            }
        }

        Time.timeScale = 0.0f;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        pauseScreen.SetActive(false);
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }



}
