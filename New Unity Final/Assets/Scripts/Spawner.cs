using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float delayBetweenSpawns = 3;
    public bool addForceOnSpawn = true;

    bool canSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        if (prefabToSpawn == null)
            Debug.Log("Hook in a prefab dummy!");

        //random initial spawn delay so that they don't all spawn at the same time.
        Invoke("EnableSpawnAgain", Random.Range(5, 10.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if(canSpawn)
        {
            if (!AsteroidManager.asteroidManagerInstance.AtLimit())
            {
                AsteroidManager.asteroidManagerInstance.currentAsteroidCount++;
                GameObject spawnedObj = Instantiate(prefabToSpawn, transform.position, transform.rotation);
                if (addForceOnSpawn)
                    spawnedObj.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * Random.Range(10, 15.0f));
                canSpawn = false;
                Invoke("EnableSpawnAgain", delayBetweenSpawns);
            }
        }
    }

    void EnableSpawnAgain()
    {
        canSpawn = true;
    }
}
