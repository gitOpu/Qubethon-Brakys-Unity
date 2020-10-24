
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	
	public void StartNow() {
        
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
