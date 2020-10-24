
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNext : MonoBehaviour {

	
	public void LoadNextLevel () {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
