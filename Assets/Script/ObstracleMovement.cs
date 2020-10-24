using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstracleMovement : MonoBehaviour {

    public Rigidbody rb;
    float AutoForce =-1000;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(0, 0, AutoForce * Time.deltaTime);
	}
}
