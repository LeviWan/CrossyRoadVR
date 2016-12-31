using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {

    private float speed = 5.0f;

    private float length;


	// Use this for initialization
	void Start () {
        float lifeTime = length / speed;
        Destroy(gameObject,lifeTime);
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += Vector3.right * speed * Time.deltaTime;
	
	}

    public void SetPath(float speed, float Length)
    {
        this.speed = speed;
        this.length = Length;
    }
}
