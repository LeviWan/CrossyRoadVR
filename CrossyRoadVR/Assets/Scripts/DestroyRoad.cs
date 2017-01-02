using UnityEngine;
using System.Collections;

public class DestroyRoad : MonoBehaviour {

    //void OnTriggerEnter(Collider collider)
    //{
    //    if (collider.gameObject.name!="Player")
    //    {
    //        Destroy(collider.gameObject);
    //    }
       
    //}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name != "Player")
        {
            ObjectPool.instance.SaveInPool(collider.gameObject);
        }

    }

    
        
    
}
