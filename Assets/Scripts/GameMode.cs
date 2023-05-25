using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    [SerializeField] private GameObject clickingHand;
    private UiController uiController;
    private Rigidbody2D playerRb;
    private SpikeSpawner spikeSpawner;
    private bool isGameStarted = false;

    private void Start()
    {
        uiController = GameObject.FindObjectOfType<UiController>() as UiController;
        playerRb = GameObject.FindObjectOfType<AirplaneController>().GetComponent<Rigidbody2D>();
        spikeSpawner = GameObject.FindObjectOfType<SpikeSpawner>() as SpikeSpawner;
        FreezeStart();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isGameStarted){
            StartGame();
        }
    }

    private void FreezeStart(){
        playerRb.simulated = false;
        spikeSpawner.enabled = false;
    }

    private void StartGame(){
        isGameStarted = true;
        playerRb.simulated = true;
        spikeSpawner.enabled = true;
        clickingHand.SetActive(false);
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
