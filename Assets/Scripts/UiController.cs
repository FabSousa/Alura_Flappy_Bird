using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private TextMeshProUGUI scoretext;

    private void Start()
    {
        GameOverUI.SetActive(false);
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
    }

    public void UpdateScore()
    {
        scoretext.text = Score.Count.ToString();
    }
}
