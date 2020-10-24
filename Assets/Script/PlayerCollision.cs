
using UnityEngine;


public class PlayerCollision : MonoBehaviour {

    public PlayerMove movment;
    
	void OnCollisionEnter( Collision collisionInfo)
    {

        if (collisionInfo.collider.tag == "Obstracle")
        {
            Debug.Log(collisionInfo.collider.name);
            movment.enabled = false;
            FindObjectOfType<GameManager>().End();
        }
       
        
    }
    
}
