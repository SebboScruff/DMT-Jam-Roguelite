using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("Score", PlayerStats.score);
            Debug.Log("You made it");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
