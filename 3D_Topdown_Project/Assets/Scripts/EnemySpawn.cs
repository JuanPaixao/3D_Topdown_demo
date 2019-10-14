using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public string directionSpawn;
    public GameObject alien, spawnPoint;

    private void Start()
    {
        float randomTime = Random.Range(1f, 10f);
        InvokeRepeating("SpawnEnemy", randomTime, randomTime);
    }
    private void SpawnEnemy()
    {
        switch (directionSpawn)
        {
            case "up":
                GameObject alienSpawnedUp = Instantiate(alien, spawnPoint.transform.position, Quaternion.Euler(0, 180, 0));
                break;
            case "down":
                GameObject alienSpawnedDown = Instantiate(alien, spawnPoint.transform.position, Quaternion.Euler(0, 0, 0));
                break;
            case "left":
                GameObject alienSpawnedLeft = Instantiate(alien, spawnPoint.transform.position, Quaternion.Euler(0, 90, 0));
                break;
            case "right":
                GameObject alienSpawnedRight = Instantiate(alien, spawnPoint.transform.position, Quaternion.Euler(0, 270, 0));
                break;
        }
    }
}
