using UnityEngine;
using System.Collections;

public class FireWallController : MonoBehaviour
{

    private GameObject player;
    public float creepSpeed = 0.01f;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameState.instance.isGameOver)
        {
            FollowPlayer();
            creepPlayer();
            BurnChecked();
        }
    }

    void FollowPlayer()
    {
        Vector3 delta = player.transform.position - transform.position;
        Vector3 projectedDelta = Vector3.Project(delta, Vector3.left);
        transform.position += projectedDelta;
    }

    void creepPlayer()
    {
        transform.position += Vector3.forward * creepSpeed;
    }

    void BurnChecked()
    {
        if (player.transform.position.z <= transform.position.z)
        {
            GameState.instance.isGameOver = true;
        }
    }
}
