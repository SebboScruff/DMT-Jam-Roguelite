using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;
    public levelgenerator levelGen;
    public string levelGenName;

    private void Start()
    {
        levelGen = GameObject.Find(levelGenName).GetComponent<levelgenerator>();
    }

    private void Update()
    {
        if (levelGen.stopGen == true)
        {
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
            Destroy(this);
        }
    }

}
