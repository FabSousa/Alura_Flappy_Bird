using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    private UiController uiController;
    private AudioController audioController;
    [SerializeField][Min(0)] private SharedFloat speed;

    private void Awake()
    {
        uiController = GameObject.FindObjectOfType<UiController>() as UiController;
        audioController = GameObject.FindObjectOfType<AudioController>() as AudioController;
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed.value);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Score.Count ++;
        uiController.UpdateScore();
        audioController.PlayScoreAudio();
    }
}
