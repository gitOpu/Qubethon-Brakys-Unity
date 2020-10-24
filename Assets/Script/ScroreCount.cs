
using UnityEngine;
using UnityEngine.UI;

public class ScroreCount : MonoBehaviour {

    public Text socreText;
    public Transform PlayerTransform;
	void Update () {
        socreText.text = PlayerTransform.position.z.ToString("0");
	}
}
