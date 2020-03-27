using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    static public int scoreInt;
    public Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        scoreInt = PlayerPrefs.GetInt("Score");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreInt;
        scoreInt = PlayerStats.score;
        

    }
}
