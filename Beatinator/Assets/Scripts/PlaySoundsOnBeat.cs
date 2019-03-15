using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Update()
    {
        if (BPM._beatFull)
        {
            _soundManager.Playsound(_tap, 1);
            if (BPM._beatCountFull % 2 == 0)
            {
                GameObject go = (GameObject)Instantiate(myPrefab1);
                _randomStrum = Random.Range(0, _strum.Length);
            }
        }
        if (BPM._beatD8 && BPM._beatcountD8 % 2 == 0)
        {
            _soundManager.Playsound(_tick, 0.1f);
        }
        if (BPM._beatD8 && (BPM._beatcountD8) % 8 == 2 || (BPM._beatcountD8) % 8 == 4)
        {
            GameObject go = (GameObject)Instantiate(myPrefab2);
            _soundManager.Playsound(_strum[_randomStrum], 1);
        }
    }
}
