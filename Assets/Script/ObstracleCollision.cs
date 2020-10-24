using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstracleCollision : MonoBehaviour {

    public ObstracleMovement movment;
    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.collider.name == "Player")
        {
            Debug.Log(collisionInfo.collider.name);
            movment.enabled = false;
        }


    }
}
