using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform fishContainer;

    private float spawnX = 8.5f;
    private float spawnY = 5.5f;

    private float countdown;
    [SerializeField] private float enemySpawnRate = 15f;
    [SerializeField] private float reduceSpawnRate = .5f;

    void Start()
    {
        countdown = enemySpawnRate;
    }

    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            SpawnEnemy();
 
            countdown = enemySpawnRate;

            enemySpawnRate -= reduceSpawnRate;

            if (enemySpawnRate <= 3)
                enemySpawnRate = 3;
        }
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-spawnX, spawnX);
        float randomY = Random.Range(-spawnY, spawnY);

        float flipCoin = Random.Range(0, 2);
        int randomPLusOrMinus = Random.Range(0, 2) * 2 - 1;

        if (flipCoin == 0)
        {
            Instantiate(enemyPrefab, new Vector3(spawnX * randomPLusOrMinus, randomY, 0.0f), Quaternion.identity, fishContainer.transform);
            SoundManager.PlaySound("Enemy");
        }
        else
        {
            Instantiate(enemyPrefab, new Vector3(randomX, spawnY * randomPLusOrMinus, 0.0f), Quaternion.identity, fishContainer.transform);
            SoundManager.PlaySound("Enemy");
        }
    }
}
