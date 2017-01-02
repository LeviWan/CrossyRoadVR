using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {

    private float speed = 5.0f;

    private float length;
   

    void OnEnable()
    {
        
        Init();
    }
   public void Init()
    {
        
       
        StartCoroutine(ReturnToPool());
    }

	// Use this for initialization
	void Start () {
        
        //Destroy(gameObject,lifeTime);
	
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
    IEnumerator ReturnToPool()
    {
         float lifeTime = length / speed;
        yield return new WaitForSeconds(12f);
        ObjectPool.instance.SaveInPool(this.gameObject);
    }
}
