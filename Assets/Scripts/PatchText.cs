using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PatchText : MonoBehaviour {

	public Text PatchKitText;
	public GameObject player;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		//PatchKitText.text = "Patch Kit: " + player.GetComponent<MovePlayer>().PatchKit;

	}

	void OnGUI()
	{
		string patchString = "Patch Kit: " + player.GetComponent<MovePlayer>().PatchKit;

		GUI.Label(new Rect(10, 40, 250, 100), patchString);
	}

}
