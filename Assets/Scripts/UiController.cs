using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] GameObject GameOverUI;

    private void Start()
    {
        GameOverUI.SetActive(false);
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
    }
}
