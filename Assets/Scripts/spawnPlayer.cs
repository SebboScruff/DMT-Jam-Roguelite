using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;
    public levelgenerator levelGen;
    public CameraFollow camFollow;
    public string levelGenName;
    public string camName;

    private void Start()
    {
        levelGen = GameObject.Find(levelGenName).GetComponent<levelgenerator>();
        camFollow = GameObject.Find(camName).GetComponent<CameraFollow>();
    }

    private void Update()
    {
        if (levelGen.stopGen == true)
        {
            GameObject player = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
            camFollow.target = player.transform;
            Destroy(this);
        }
    }

}
