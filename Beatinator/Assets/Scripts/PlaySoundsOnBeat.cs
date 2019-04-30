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

    public Animation left, right;

    private void Start()
    {

        left.gameObject.GetComponent<Animation>().enabled = false;
        right.gameObject.GetComponent<Animation>().enabled = false;
    }


    void Update()
    {
        if (BPM._beatFull)
        {
            _soundManager.Playsound(_tap, 1);
            if (BPM._beatCountFull % 2 == 0)
            {
                left.gameObject.GetComponent<Animation>().enabled = true;
                right.gameObject.GetComponent<Animation>().enabled = true;

                GameObject go = (GameObject)Instantiate(myPrefab1, transform.position, Quaternion.identity);
                _randomStrum = Random.Range(0, _strum.Length);
            }
        }
        if (BPM._beatD8 && BPM._beatcountD8 % 2 == 0)
        {
          //  _soundManager.Playsound(_tick, 0.1f);
        }
        if (BPM._beatD8 && (BPM._beatcountD8) % 8 == 2 || (BPM._beatcountD8) % 8 == 4)
        {
            //GameObject go = (GameObject)Instantiate(myPrefab2, transform.position, transform.rotation);
            //_soundManager.Playsound(_strum[_randomStrum], 1);
        }
    }
}
