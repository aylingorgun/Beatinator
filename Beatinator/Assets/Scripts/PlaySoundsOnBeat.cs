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

    //Testing following enemies, definitely remove
    public GameObject followerBox;
    private FollowingEnemy feScript;

    private void Start()
    {
        chaser = FindObjectOfType<ChaserFollow>();
        Instantiate(followerBox, new Vector3(4, 1, 4), followerBox.transform.rotation);
        feScript = FindObjectOfType<FollowingEnemy>();
    }

    public void FullBeatMovement()
    {
        //_soundManager.Playsound(_tap, 1);
        
        //These are messed up
        //Should not be calling every fe script directly
        if (BPM._beatCountFull % 4 == 0)
        {
            chaser.GetCloser();
            feScript.MoveTowards();
        }
        else if(BPM._beatCountFull % 2 == 0)
        {
            feScript.MoveTowards();
        }
        else
            chaser.CheckIfLeftBehind();
    }
}
