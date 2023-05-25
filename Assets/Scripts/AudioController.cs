using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip ScoreAudio;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayScoreAudio(){
        audioSource.PlayOneShot(ScoreAudio);
    }
}
