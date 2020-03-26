using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;
   

public class MusicControl : MonoBehaviour
{
    //Use this value to change the vapour of the music
    [Range(0f, 1f)]public float vapourMeter;

    private void Awake()
    {
        //Don't destroy the music on transitioning level
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checks and changes the vapour meter in FMOD
        GetComponent<StudioEventEmitter>().EventInstance.setParameterByName("VapourMeter", vapourMeter);
    }
}
