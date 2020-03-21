using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;
   

public class MusicControl : MonoBehaviour
{
    [Range(0f, 1f)]public float vapourMeter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<StudioEventEmitter>().EventInstance.setParameterByName("VapourMeter", vapourMeter);
    }
}
