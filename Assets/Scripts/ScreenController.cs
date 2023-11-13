using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    private AirplaneController player;
    private ImageLoop[] backgroundLoop;
    private SpikeSpawner spikeSpawner;

    private void Start()
    {
        backgroundLoop = GetComponentsInChildren<ImageLoop>();
        spikeSpawner = GetComponentInChildren<SpikeSpawner>();
        player = GetComponentInChildren<AirplaneController>();
    }

    public void onGameOver(){
        foreach(ImageLoop i in backgroundLoop){
            i.enabled = false;
        }
        spikeSpawner.enabled = false;
    }

    public void Activate(){
        foreach(ImageLoop i in backgroundLoop){
            i.enabled = true;
        }
        spikeSpawner.enabled = true;
        player.enabled = true;
        player.Activate();
    }
}
