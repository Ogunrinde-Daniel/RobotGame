using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Extra : MonoBehaviour
{
    public void Restart()
    {
        LastCheckPoint.checkPointPosition = Vector3.zero;
        SceneManager.LoadScene(0);    
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
