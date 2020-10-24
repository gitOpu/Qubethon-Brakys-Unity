
using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public GameManager GM;
	public void OnTriggerEnter()
    {
        GM.LevelComplete();
    }
}
