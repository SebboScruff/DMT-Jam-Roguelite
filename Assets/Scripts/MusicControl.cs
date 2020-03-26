using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name.Contains("Menu"))
        {
            vapourMeter = 1;
        }

        if (scene.name == "Level")
        {
            vapourMeter = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Level")
        {
            vapourMeter = Mathf.Lerp(vapourMeter, 0, 1.2f * Time.deltaTime);
        }

        if (scene.name.Contains("Menu"))
        {
            vapourMeter = Mathf.Lerp(vapourMeter, 1, 1.2f * Time.deltaTime);
        }



        //Checks and changes the vapour meter in FMOD
        GetComponent<StudioEventEmitter>().EventInstance.setParameterByName("VapourMeter", vapourMeter);
    }
}
