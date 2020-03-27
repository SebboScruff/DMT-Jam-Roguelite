using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public float health;
    [SerializeField] private float maxHealth = 5f;
    static public int score;

    public Image healthBar;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Die();
        }
        Debug.Log("Current health: " + health);
        Debug.Log("Current score: " + score);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = health / 5;
    }

    void Die()
    {
        //insntantiate a fancy particle system please
        //maybe add a small delay so we can see it as well
        PlayerPrefs.SetInt("Score", score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Debug.Log("I died not clickbait");
    }
}
