using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseCanvas;
    public static bool isPaused;


    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pauseCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused == false)
            {
                PauseMethod();
            }
            else
            {
                Resume();
            }
        }
    }

    void PauseMethod()
    {
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
        isPaused = true;
    }

    void Resume()
    {
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false);
        isPaused = false;
    }
}
