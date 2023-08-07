using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    [SerializeField] private float rotSpeed = 2;

    private Rigidbody2D rb;

    private Vector3 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(moveHorizontal, moveVertical, 0).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * speed * Time.fixedDeltaTime;

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.back, movement), rotSpeed * Time.fixedDeltaTime);
        }
    }
}
