using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatBarMovement : MonoBehaviour
{
    public RectTransform source;
    public RectTransform L1;
    public RectTransform L2;
    public RectTransform L3;
    public RectTransform R1;
    public RectTransform R2;
    public RectTransform R3;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(L1.position.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
