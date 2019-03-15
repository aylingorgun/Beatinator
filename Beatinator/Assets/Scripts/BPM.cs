using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPM : MonoBehaviour
{
    /*  This script contains your MAIN metronome logic.
        We are using Time.deltaTime to calculate the beats and dividing by 60 we find beat per minute.
        In tapping class your calculating distances betwwen tappings and then divide by 60
        There are 60/8 and 60/4 notes. 
    */
    private static BPM _BPMInstance;

    public float _bpm;
    private float _beatInterval, _beatTimer, _beatIntervalD8, _beatTimerD8;
    public static bool _beatFull, _beatD8;
    public static int _beatCountFull, _beatcountD8;

    public float[] _tapTime = new float[4];
    public static int _tap;
    public static bool _customBeat;

    private void Awake()
    {
        if (_BPMInstance != null && _BPMInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _BPMInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
 
    void Update()
    {
        //Tapping();
        BeatDetection();
    }

    #region
    void Tapping()
    {
        //This is custom meteronome
        if (Input.GetKeyUp(KeyCode.F1))
        {
            _customBeat = true;
            _tap = 0;
        }
        if (_customBeat)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_tap < 4)
                {
                    _tapTime[_tap] = Time.realtimeSinceStartup;
                    _tap++;
                }
                if (_tap == 4)
                {
                    float averageTime = ((_tapTime[1] - _tapTime[0]) + (_tapTime[2] - _tapTime[1]) +
                        (_tapTime[3] - _tapTime[2])) / 3;
                    _bpm = (float)System.Math.Round((double)60 / averageTime, 2);
                    _tap = 0;
                    _beatTimer = 0;
                    _beatTimerD8 = 0;
                    _beatCountFull = 0;
                    _customBeat = false;
                }
            }
        }
    }
    #endregion


    void BeatDetection()
    {
        //Full beat count
        _beatFull = false;
        _beatInterval = 60 / _bpm;
        _beatTimer += Time.deltaTime;
        if (_beatTimer >= _beatInterval)
        {
            _beatTimer -= _beatInterval;
            _beatFull = true;
            _beatCountFull++;
            Debug.Log("Full");
        }
        //Divided beat count
        _beatD8 = false;
        _beatIntervalD8 = _beatInterval / 8;
        _beatTimerD8 += Time.deltaTime;
        if (_beatTimerD8 >= _beatIntervalD8)
        {
            _beatTimerD8 -= _beatIntervalD8;
            _beatD8 = true;
            _beatcountD8++;
            Debug.Log("D8");
        }
    }



}
