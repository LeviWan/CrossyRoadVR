using UnityEngine;
using System.Collections;

public class VehicleSpawner : MonoBehaviour {

    public GameObject[] vehiclePrefabs;
    public float HeightOffset = 1.0f;
    public float StartOffset = -10f;
    public float Speed = 5.0f;
    public float Length = 20.0f;
    public float maxSpawnTime = 10.0f;
	void Start () {
        StartCoroutine(Spawn());
	}

    void CreateVehicle()
    {
       
        int vehiclePrefabsIndex=Random.Range(0, vehiclePrefabs.Length);

        GameObject vehicleObj = Instantiate(vehiclePrefabs[vehiclePrefabsIndex]);

        vehicleObj.transform.position = GetPositionOffset();
        vehicleObj.transform.parent = transform;
        Vehicle vehicle = vehicleObj.GetComponent<Vehicle>();
        vehicle.SetPath(Speed, Length);
    }

    Vector3 GetPositionOffset()
    {
        Vector3 PositionOffset = transform.position;
        //高度的偏移
        PositionOffset += HeightOffset * Vector3.up;
        //宽度的偏移
        PositionOffset += StartOffset * Vector3.right;
        return PositionOffset;
    }

    IEnumerator Spawn()
    {
        while (true)
        {
           
            WaitForSeconds waitTime=new WaitForSeconds(Random.Range(0.5f,maxSpawnTime));
            yield return waitTime;
            CreateVehicle();
        }
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
