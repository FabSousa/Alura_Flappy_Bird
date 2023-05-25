using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private TextMeshProUGUI scoretext;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private Image medalSlot;
    [SerializeField] private Sprite bronzeMedal;
    [SerializeField] private Sprite silverMedal;
    [SerializeField] private Sprite goldMedal;
    private int score;

    private void Start()
    {
        GameOverUI.SetActive(false);
    }

    public void GameOver()
    {
        UpdateMedal();
        UpdateBestScore();
        GameOverUI.SetActive(true);
    }

    public void UpdateScore()
    {
        score = Score.Count;
        scoretext.text = score.ToString();
    }

    private void UpdateBestScore()
    {
        bestScoreText.text = Score.BestScore.ToString();
    }

    private void UpdateMedal()
    {
        if (score >= Score.BestScore)
            medalSlot.sprite = goldMedal;
        else if (score > Score.BestScore / 2)
            medalSlot.sprite = silverMedal;
        else
            medalSlot.sprite = bronzeMedal;
    }
}
