using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public Transform spriteTrans;

    [SerializeField] float speed = 2f;

    private Vector3 dir;
    private Transform player;


    private void OnEnable()
    {
        player = FindObjectOfType<PlayerController>().transform;

        dir = player.transform.position - transform.position;
    }

    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        spriteTrans.transform.rotation = Quaternion.LookRotation(Vector3.back, dir);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundaries"))
        {
            Destroy(gameObject);
        }
    }
}
