using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    [SerializeField] private GameObject clickingHand;
    [SerializeField] private Rigidbody2D player1Rb;
    [SerializeField] private GameObject player2;
     private Rigidbody2D player2Rb;
    private UiController uiController;
    private SpikeSpawner[] spikeSpawner;
    private bool isGameStarted = false;

    protected virtual void Start()
    {
        if(player1Rb == null)
            player1Rb = GameObject.FindObjectOfType<AirplaneController>().GetComponent<Rigidbody2D>();
        if(player2 != null)
            player2Rb = player2.GetComponent<Rigidbody2D>();
        uiController = GameObject.FindObjectOfType<UiController>() as UiController;
        spikeSpawner = GameObject.FindObjectsOfType<SpikeSpawner>() as SpikeSpawner[];
        FreezeStart();
    }

    private void FreezeStart(){
        player1Rb.simulated = false;
        if(player2Rb != null){
            player2Rb.simulated = false;
            player2.GetComponent<AutoLeap>().enabled = false;
        }

        foreach(SpikeSpawner s in spikeSpawner){
            s.enabled = false;
        }
    }

    public void StartGame(){
        if(isGameStarted) return;

        isGameStarted = true;
        player1Rb.simulated = true;
        if(player2Rb != null){
            player2Rb.simulated = true;
            player2.GetComponent<AutoLeap>().enabled = true;
        }
        foreach(SpikeSpawner s in spikeSpawner){
            s.enabled = true;
        }
        
        clickingHand.SetActive(false);
    }

    public void GameOver()
    {
        Score.SaveBestScore();
        Time.timeScale = 0;
        Score.Count = 0;
        uiController.GameOver();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
