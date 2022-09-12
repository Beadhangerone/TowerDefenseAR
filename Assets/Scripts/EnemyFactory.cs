using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public List<GameObject> waypointsList = new List<GameObject>();
    public int spawnDelaySeconds = 2;
    public List<GameObject> enemyVariants = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitForSpawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<GameObject> getWaypointList()
    {
        return new List<GameObject>(waypointsList);
    }
    IEnumerator waitForSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelaySeconds);
            createEnemy();
        }
    }
    public void createEnemy()
    {
        GameObject newEnemy = Instantiate(enemyVariants[Random.Range(0, enemyVariants.Count)], transform.position,
            Quaternion.identity);
        newEnemy.GetComponent<Enemy>().WaypointList = getWaypointList();
    }
}
