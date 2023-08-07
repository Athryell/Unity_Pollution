using UnityEngine;

public class FluffyFishSpawner : MonoBehaviour
{
    public GameObject fluffyPrefab;
    public Transform fishContainer;

    private float spawnX = 8.5f;
    private float spawnY = 5.5f;

    private float countdown;
    [SerializeField] private float fluffySpawnRate = 25f;

    void Start()
    {
        countdown = fluffySpawnRate;
    }

    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            SpawnFluffy();
            countdown = fluffySpawnRate;
        }
    }

    void SpawnFluffy()
    {
        float randomX = Random.Range(-spawnX, spawnX);
        float randomY = Random.Range(-spawnY, spawnY);

        float flipCoin = Random.Range(0, 2);
        int randomPLusOrMinus = Random.Range(0, 2) * 2 - 1;

        if (flipCoin == 0)
        {
            Instantiate(fluffyPrefab, new Vector3(spawnX * randomPLusOrMinus, randomY, 0.0f), Quaternion.identity, fishContainer.transform);
            SoundManager.PlaySound("Fluffy");
        }
        else
        {
            Instantiate(fluffyPrefab, new Vector3(randomX, spawnY * randomPLusOrMinus, 0.0f), Quaternion.identity, fishContainer.transform);
            SoundManager.PlaySound("Fluffy");
        }
    }
}
