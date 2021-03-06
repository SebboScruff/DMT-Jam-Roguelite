﻿using System.Collections;
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
        if (other.tag == "Player")
        {
            Instantiate(scoreCanvas, transform.position, Quaternion.identity);
            PlayerStats.score += scoreValue;
        }

        Destroy(this.gameObject);
    }
}
