using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] LanePrefabs;
    public float SpawnHorizon=500f;
    public float LaneWidth = 2f;
    public GameObject player;

    public Transform SpawnerPosition;


    private float NextLaneOffset = 0f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float forwardPosition = player.transform.position.z;
        while (forwardPosition+SpawnHorizon>NextLaneOffset)
        {
            int randomLaneIndex = Random.Range(0, LanePrefabs.Length);
            GameObject lane = LanePrefabs[randomLaneIndex];
            Vector3 NextLanePosition = NextLaneOffset * Vector3.forward;
           GameObject NewLaneObject= Instantiate(lane,NextLanePosition,Quaternion.identity) as GameObject;
           NewLaneObject.transform.parent = SpawnerPosition;
            NextLaneOffset += LaneWidth;
        }
	
	}
}
