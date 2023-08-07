using UnityEngine;

public class FluffyMover : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float minRotSpeed = 1.5f;
    [SerializeField] float maxRotSpeed = 3.5f;

    private float rotSpeed;

    private Vector2 dir;

    private void OnEnable()
    {
        dir = new Vector2((Vector2.zero.x - transform.position.x), (Vector2.zero.y - transform.position.y));
        rotSpeed = Random.Range(minRotSpeed, maxRotSpeed);
    }

    void Update()
    {
        transform.parent.Translate(dir * speed * Time.deltaTime);

        transform.Rotate(Vector3.forward * rotSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundaries"))
        {
            Destroy(gameObject);
        }
    }
}
