using UnityEngine;
using System.Collections;

public class GameOverMessage : MonoBehaviour {



    public float HorizonDistanceFromPlayer = 2.0f;
    public float VerticalDistanceFromPlayer = 0.01f;

    //follow Player's Head Rotation
    private Player player;

    private Canvas canvas;

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    void Update()
    {
       
        if (GameState.instance.isGameOver)
        {
            TrackPlayer();
            canvas.enabled = true;
        }
    }

    void TrackPlayer()
    {
        transform.rotation = Quaternion.LookRotation(player.LookDirection());
        transform.position = player.transform.position;
        transform.position += player.LookDirection() * HorizonDistanceFromPlayer;
        transform.position += Vector3.up * VerticalDistanceFromPlayer;


        
 
    }

}
