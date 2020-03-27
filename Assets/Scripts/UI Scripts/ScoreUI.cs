using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public int scoreInt;
    public Text scoreText;

    public PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreInt;
        scoreInt = playerStats.score;
    }
}
