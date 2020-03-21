using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartGifCycle : MonoBehaviour
{
    public Texture[] frames = new Texture[23];
    public int fps = 24;
    public Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material; 
    }

    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.time * fps) % frames.Length;
        mat.mainTexture = frames[index];
    }
}
