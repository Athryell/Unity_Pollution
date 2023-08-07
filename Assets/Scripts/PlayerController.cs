using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public NetStuckHandler netStuck;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Net"))
        {
            SoundManager.PlaySound("Stuck");

            int x = 0;
            while (x < 6)
            {
                netStuck.AddLoop();
                x++;
            }

            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Enemy"))
        {
            SoundManager.PlaySound("Bite");

            GameManager.Instance.lifes--;
            UIManager.Instance.UpdateLifeCount();

            //Animation

            if (GameManager.Instance.lifes <= 0)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}
