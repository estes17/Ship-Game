using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PatchText : MonoBehaviour {

	public Text PatchKitText;
	public GameObject player;
	public GameObject GameManager;
	public GUIStyle largeFont;

	// Use this for initialization
	void Start()
	{

		largeFont.fontSize = 20;
		largeFont.normal.textColor = Color.white;
	}

	// Update is called once per frame
	void Update()
	{

		//PatchKitText.text = "Patch Kit: " + player.GetComponent<MovePlayer>().PatchKit;

	}

	void OnGUI()
	{
		if (Time.time < 300 && GameManager.GetComponent<GameManager> ().gameOver == false)
		{
			string patchString = "Patch Kits: " + player.GetComponent<MovePlayer>().PatchKit;

			GUI.Label(new Rect(10, 50, 250, 100), patchString, largeFont);
		}
	}

}
