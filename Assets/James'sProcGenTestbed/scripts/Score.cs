using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int scoreValue;
    public GameObject scoreCanvas;
    public string playerName;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.name == playerName)
        {
            Instantiate(scoreCanvas, transform.position, Quaternion.identity);
            PlayerStats playerStats = other.gameObject.GetComponentInChildren<PlayerStats>();
            playerStats.score += scoreValue;
        }

        Destroy(this.gameObject);
    }
}
