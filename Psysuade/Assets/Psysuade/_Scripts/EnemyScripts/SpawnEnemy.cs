using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    public GameObject[] prefabEnemies;
    public GameObject[] spawnPoints;

    // public float minSecondsBetweenSpawning = 3.0f;
    // public float maxSecondsBetweenSpawning = 6.0f;

    public Transform chaseTarget;
    public int enemyCount = 0;
    public int wave = 0;
    // public int startEnemyCount = 3;
    // public int addPerWave = 2;
    public float spawnWait = 0;
    public float startWait = 0;
    public float waveWait = 0;
    //private float savedTime;
    //private float secondsBetweenSpawning;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(MakeThingToSpawn());
    }

    IEnumerator MakeThingToSpawn()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for (int i=0; i<enemyCount; i++)
            {
                // create a new gameObject
                int ndx = Random.Range(0, prefabEnemies.Length);
                int sp = Random.Range(0, spawnPoints.Length);
                GameObject clone = Instantiate(prefabEnemies[ndx], spawnPoints[sp].transform.position, transform.rotation);

                // set chaseTarget if specified
                if ((chaseTarget != null) && (clone.gameObject.GetComponent<Enemy>() != null))
                {
                    clone.gameObject.GetComponent<Enemy>().SetTarget(chaseTarget);
                }
                if ((chaseTarget != null) && (clone.gameObject.GetComponent<EnemyThrower>() != null))
                {
                    clone.gameObject.GetComponent<EnemyThrower>().SetTarget(chaseTarget);
                }
                yield return new WaitForSeconds(spawnWait);
            }
            
            yield return new WaitForSeconds(waveWait);
            EndWave();
        }
        
    }

    void EndWave()
    {
        wave++;
        enemyCount++;
        StopCoroutine(MakeThingToSpawn());
        //StartCoroutine(MakeThingToSpawn());
    }
}
