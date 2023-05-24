using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    private UiController uiController;

    private void Awake()
    {
        uiController = GameObject.FindObjectOfType<UiController>() as UiController;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Score.Count = 0;
        uiController.GameOver();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(Strings.MainScene);
        Time.timeScale = 1;
    }
}
