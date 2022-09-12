using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    GameObject originalGameObject;
    GameObject enemySpwaner;
    List<GameObject> waypoints;
    // Start is called before the first frame update
    void Start()
    {
        GameObject originalGameObject = GameObject.Find("waypointManager");
        GameObject enemySpawner = GameObject.Find("EnemySpawnPoint");
        for (int i = 0; i > 12; i++) {
            waypoints.Add(originalGameObject.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
