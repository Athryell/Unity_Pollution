using System.Collections.Generic;
using UnityEngine;

public class NetStuckHandler : MonoBehaviour

{
    public GameObject loopPrefab;
    public Transform player;
    public Rigidbody2D playerRb2D;
    public HingeJoint2D playerHinge;
    public Transform net;

    [SerializeField] private List<GameObject> loopsList = new List<GameObject>();
    [SerializeField] private List<GameObject> tempList = new List<GameObject>();

    private Vector2 previousLoopPos;
    private Vector2 yOffset = new Vector2(0f, -0.5f);
    private int loopName = 1;

    public void AddLoop()
    {
        if (loopsList.Count == 0)
        {
            previousLoopPos = player.transform.position;
        }
        else
        {
            previousLoopPos = loopsList[loopsList.Count - 1].transform.position;
        }

        GameObject loop = Instantiate(loopPrefab, previousLoopPos + yOffset, Quaternion.identity);

        loopsList.Add(loop);
        loop.transform.SetParent(net);

        HingeJoint2D[] hj = loop.GetComponents<HingeJoint2D>();
        hj[0].enabled = false;
        hj[1].enabled = false;

        GameManager.Instance.numberOfLoopsAttached = loopsList.Count;

        loop.transform.name = loopName.ToString();

        loopName++;

        if (loop.name == "1")
        {
            playerHinge.enabled = true;
            playerHinge.connectedBody = loop.GetComponent<Rigidbody2D>();
            return;
        }

        HingeJoint2D[] previousLoopHinge = loopsList[loopsList.Count - 2].GetComponents<HingeJoint2D>();

        previousLoopHinge[0].enabled = true;
        previousLoopHinge[0].connectedBody = loop.GetComponent<Rigidbody2D>();

    }

    public void RemoveLoop(GameObject loopGameObject)
    {
        if (loopsList.IndexOf(loopGameObject) == 0)
            return;

        int index = loopsList.IndexOf(loopGameObject);

        if (index <= loopsList.Count)
        {
            loopsList.RemoveRange(index, loopsList.Count - index);

            GameManager.Instance.numberOfLoopsAttached = loopsList.Count;
        }

        if (loopsList.Count == 0 || loopsList == null)
        {
            previousLoopPos = player.transform.position;
        }
    }
}
