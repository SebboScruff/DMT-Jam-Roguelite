using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour
{
    public int health;
    [SerializeField] private int maxHealth = 5;
    public int score;

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
    }

    void Die()
    {
        //insntantiate a fancy particle system please
        //maybe add a small delay so we can see it as well

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Debug.Log("I died not clickbait");
    }
}
