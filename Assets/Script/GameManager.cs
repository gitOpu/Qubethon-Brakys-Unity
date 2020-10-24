
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    bool endGame = false;
    public GameObject panel;
    public PlayerMove movment;
    public GameObject Gameover;
	public void End()
    {
        if (endGame == false)
        {
            endGame = true;
            Gameover.SetActive(true); 
            //Debug.Log("End Game" + endGame);
            Invoke("Restart", 2f);
        }
       
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LevelComplete()
    {
        Debug.Log("Level Complete");
        panel.SetActive(true);
        movment.enabled = false;


    }
    
}
