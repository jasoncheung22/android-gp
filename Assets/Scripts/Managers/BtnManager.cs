using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour {

    public void GameStart()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        ScoreManager.score = 0;
        SceneManager.LoadScene("L01 backup");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ReturnMain()
    {
        ScoreManager.score = 0;
        SceneManager.LoadScene("MainMenu");
    }
}
