using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	// Use this for initialization
    public Rigidbody rb;
    public float forwardForce;
    public float SideForce;

	void Start () {
		
	}


    void Update()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (Input.GetKey("a"))
        {
            rb.AddForce(-SideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(SideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().End();
        }

	}
}
