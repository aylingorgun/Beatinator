using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySoundsOnBeat : MonoBehaviour
{
    public SoundManager _soundManager;
    //Base voices metronome
    public AudioClip _tap, _tick;
    //Your library of sounds
    public AudioClip[] _strum;
    int _randomStrum;
    //Your items that will be created according to your beat
    public GameObject myPrefab1, myPrefab2;
    private ChaserFollow chaser;

    private void Start()
    {
        chaser = FindObjectOfType<ChaserFollow>();
    }

    public void FullBeatMovement()
    {
        //_soundManager.Playsound(_tap, 1);
        if (BPM._beatCountFull % 4 == 0)
        {
            chaser.GetCloser();
        }

        else
            chaser.CheckIfLeftBehind();
    }
}
