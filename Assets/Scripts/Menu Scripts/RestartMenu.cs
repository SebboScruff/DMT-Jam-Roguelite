using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(1); // or whatever the main game scene is
    }

    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
