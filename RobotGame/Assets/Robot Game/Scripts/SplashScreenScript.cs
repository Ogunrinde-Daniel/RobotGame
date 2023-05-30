using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("MoveToMenu", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveToMenu()
    {
        SceneManager.LoadScene("Menu Scene");
    }
}
