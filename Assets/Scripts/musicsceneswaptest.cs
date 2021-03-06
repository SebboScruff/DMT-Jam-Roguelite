﻿using UnityEngine;
using UnityEngine.SceneManagement;

// Object.DontDestroyOnLoad example.
//
// Two scenes call each other. This happens when OnGUI button is clicked.
// scene1 will load scene2; scene2 will load scene1. Both scenes have
// the Menu GameObject with the SceneSwap.cs script attached.
//
// AudioSource plays an AudioClip as the game runs. This is on the
// BackgroundMusic GameObject which has a music tag.  The audio
// starts in AudioSource.playOnAwake. The DontDestroy.cs script
// is attached to BackgroundMusic.

public class musicsceneswaptest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Scene scene = SceneManager.GetActiveScene();

            if (scene.name == "dontdestroymusic1")
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}