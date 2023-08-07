using UnityEngine;

public class CrabMover : MonoBehaviour
{
    [SerializeField] private float speed = 2;

    private float xOffset = 8f;

    private Vector2 movement = Vector2.right;

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(movement * speed * Time.deltaTime);

        if (transform.position.x < -xOffset || transform.position.x > xOffset)
        {
            InvertSpeed();
        }
    }

    void InvertSpeed()
    {
        speed *= -1;
    }

    public void StopMovement()
    {
        speed = 0;
    }
}
