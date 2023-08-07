using UnityEngine;

public class PlayerFollowMouse : MonoBehaviour
{
    [SerializeField] private int speed = 5;

    private Rigidbody2D rb;

    private Vector2 pos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = pos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90;
        rb.rotation = angle;
        
        transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.fixedDeltaTime);
    }
}
