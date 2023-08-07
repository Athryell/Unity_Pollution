using UnityEngine;

public class CoralGrowth : MonoBehaviour
{
    [SerializeField] private float timeOfSlerpGrowing = 3f;
    [SerializeField] private int minGrowthRate = 15;
    [SerializeField] private int maxGrowthRate = 30;

    private int randomGrowthRate;
    private float countdown;
    private Vector3 nextScale;

    void Start()
    {
        float randomScale = Random.Range(0.8f, 1.2f);
        transform.localScale = new Vector3(randomScale, randomScale, 0);

        nextScale = transform.localScale * Random.Range(1.3f, 2f);

        randomGrowthRate = Random.Range(minGrowthRate, maxGrowthRate);
        countdown = randomGrowthRate;
    }

    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, nextScale, timeOfSlerpGrowing * Time.deltaTime);

            if (transform.localScale == nextScale)
            {
                countdown = Random.Range(minGrowthRate, maxGrowthRate);
                nextScale = transform.localScale * Random.Range(1.3f, 2f);
            }
        }
    }
}
