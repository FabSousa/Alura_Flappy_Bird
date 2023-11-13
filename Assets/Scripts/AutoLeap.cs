using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLeap : MonoBehaviour
{
    private AirplaneController player;
    private float leapDelayInSec = 1.1f;

    private void Awake()
    {
        player = GetComponent<AirplaneController>();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnEnable()
    {
        StartCoroutine(Leap());
    }

    private IEnumerator Leap(){
        yield return new WaitForSeconds(0.3f);
        while (true){
            player.Impulse();
            yield return new WaitForSeconds(leapDelayInSec);
        }
    }
}
