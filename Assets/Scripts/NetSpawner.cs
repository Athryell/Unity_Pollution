using UnityEngine;

public class NetSpawner : MonoBehaviour
{
    public GameObject netPrefab;

    private float spawnX = 8.5f;
    private float spawnY = 5.5f;

    private float countdown;
    [SerializeField] private float netSpawnRate = 25f;
    [SerializeField] private float reduceSpawnRate = 1;


    void Start()
    {
        countdown = netSpawnRate;
    }

    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            SpawnNet();
            countdown = netSpawnRate;

            netSpawnRate -= reduceSpawnRate;

            if (netSpawnRate <= 3)
                netSpawnRate = 3;
        }
    }

    void SpawnNet()
    {
        float randomX = Random.Range(-spawnX, spawnX);
        float randomY = Random.Range(-spawnY, spawnY);

        float flipCoin = Random.Range(0, 2);
        int randomPLusOrMinus = Random.Range(0, 2) * 2 - 1;

        if (flipCoin == 0)
        {
            Instantiate(netPrefab, new Vector3(spawnX * randomPLusOrMinus, randomY, 0.0f), Quaternion.identity);
        }
        else
        {
            Instantiate(netPrefab, new Vector3(randomX, spawnY * randomPLusOrMinus, 0.0f), Quaternion.identity);
        }
    }
}
