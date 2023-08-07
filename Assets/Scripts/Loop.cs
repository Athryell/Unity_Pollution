using UnityEngine;

public class Loop : MonoBehaviour
{
    private NetStuckHandler netHandler;
    private HingeJoint2D[] hj;

    private void Start()
    {
        netHandler = FindObjectOfType<NetStuckHandler>();
        hj = GetComponents<HingeJoint2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coral"))
        {
            if (hj[1].enabled == false)
            {
                hj[1].enabled = true;
                hj[1].connectedBody = collision.GetComponent<Rigidbody2D>();
            }
        }
        if (collision.CompareTag("Fluffy"))
        {
            if (hj[1].enabled == false)
            {
                collision.GetComponent<FluffyMover>().enabled = false;
                collision.gameObject.tag = "Default";

                hj[1].enabled = true;
                hj[1].connectedBody = collision.GetComponent<Rigidbody2D>();

                GameManager.Instance.score += 100;
            }
        }
        if (collision.CompareTag("Crab"))
        {
            SoundManager.PlaySound("Cut");

            hj[0].enabled = false;
            hj[1].enabled = false;

            netHandler.RemoveLoop(gameObject);
        }
    }
}
