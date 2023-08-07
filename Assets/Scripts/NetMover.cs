using UnityEngine;

public class NetMover : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] int rotSpeed;

    private Vector2 dir;
    public Transform loops;

    private void OnEnable()
    {
        dir = Vector3.zero - transform.position;
        rotSpeed = 2;
    }

    void Update()
    {
        if (loops == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.Translate(dir * speed * Time.deltaTime);

        loops.transform.Rotate(Vector3.forward * rotSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundaries"))
        {
            Destroy(this.gameObject);
        }
    }
}
