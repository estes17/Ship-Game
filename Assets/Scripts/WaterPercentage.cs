using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaterPercentage : MonoBehaviour {

	public Text WaterPercentText;
	public GameObject GameManager;
	public GUIStyle largeFont;

	// Use this for initialization
	void Start () {

		largeFont.fontSize = 20;
		largeFont.normal.textColor = Color.white;

	}

	// Update is called once per frame
	void Update () {



		//WaterPercentText.text = WaterPercentCalculation+ "%";



	}


	void OnGUI()
	{
		if (Time.time < 300 && GameManager.GetComponent<GameManager> ().gameOver == false) {
			int WaterPercentCalculation = (int)((GameManager.GetComponent<GameManager> ().WaterPercent / 48.75f) * 100.0f);
			string WaterCalc = "Percent Filled: " + WaterPercentCalculation + "% / 66%";


			GUI.Label (new Rect (10, 30, 250, 100), WaterCalc, largeFont);
		}
	}
}
