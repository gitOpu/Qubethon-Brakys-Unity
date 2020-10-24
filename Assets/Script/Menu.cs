
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	
	public void StartGameNow () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
