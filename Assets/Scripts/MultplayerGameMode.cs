using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultplayerGameMode : GameMode
{
    private ScreenController[] players;
    private bool needToRevive;
    private float pointsToRevive;
    [SerializeField] int pointsNeededToRevive = 3;

    protected override void Start()
    {
        base.Start();
        players = GameObject.FindObjectsOfType<ScreenController>();
    }

    public void PlayerDied(){
        pointsToRevive = 0;
        needToRevive = true;
    }

    public void TryToRevive(){
        if(needToRevive){
            pointsToRevive++;
            if (pointsToRevive >= pointsNeededToRevive){
                RevivePlayers();
            }
        }
    }

    private void RevivePlayers(){
        foreach(var player in players){
            player.Activate();
        }
        needToRevive = false;
    }

}
