using UnityEngine;
using System.Collections;

public class CollisionOfVehicle : MonoBehaviour {

    void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.tag=="Vehicle")
        {
            GameState.instance.isGameOver = true;
        }
    }
}
