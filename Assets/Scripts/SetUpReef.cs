using UnityEngine;

public class SetUpReef : MonoBehaviour
{
    public GameObject reefPrefab;
    public GameObject crabPrefab;

    public Transform reefContainer;

    [SerializeField] private int maxNumOfCoralPerSide = 4;
    [SerializeField] private int minNumOfCoralPerSide = 2;

    private float width = 8f;
    private float height = 5f;
    private float offset = 0.5f;

    void Start()
    {
        SpawnCrabs();

        SpawnCoralBottom();
        SpawnCoralTop();
        SpawnCoralRight();
        SpawnCoralLeft();
    }

    void SpawnCrabs()
    {
        Instantiate(crabPrefab, new Vector2(Random.Range(-width + offset, width - offset), -height), Quaternion.identity, reefContainer);
        Instantiate(crabPrefab, new Vector2(Random.Range(-width + offset, width - offset), height), Quaternion.Euler(new Vector3(0, 0, 180)), reefContainer);
    }

    void SpawnCoralBottom()
    {
        for (int i = 0; i < Random.Range(minNumOfCoralPerSide, maxNumOfCoralPerSide); i++)
        {
           GameObject go = Instantiate(reefPrefab, new Vector2(Random.Range(-width + offset, width - offset), -height), Quaternion.identity, reefContainer);
        }
    }
    void SpawnCoralTop()
    {
        for (int i = 0; i < Random.Range(minNumOfCoralPerSide, maxNumOfCoralPerSide); i++)
        {
            GameObject go = Instantiate(reefPrefab, new Vector2(Random.Range(-width + offset, width - offset), height), Quaternion.Euler(new Vector3(0, 0, 180)), reefContainer);
        }
    }
    void SpawnCoralRight()
    {
        for (int i = 0; i < Random.Range(minNumOfCoralPerSide, maxNumOfCoralPerSide); i++)
        {
            GameObject go = Instantiate(reefPrefab, new Vector2(width, Random.Range(-height + offset, height - offset)), Quaternion.Euler(new Vector3(0, 0, 90)), reefContainer);
        }
    }
    void SpawnCoralLeft()
    {
        for (int i = 0; i < Random.Range(minNumOfCoralPerSide, maxNumOfCoralPerSide); i++)
        {
            GameObject go = Instantiate(reefPrefab, new Vector2(-width, Random.Range(-height + offset, height - offset)), Quaternion.Euler(new Vector3(0, 0, -90)), reefContainer);
        }
    }
}
