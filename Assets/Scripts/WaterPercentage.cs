using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaterPercentage : MonoBehaviour {

	public Text WaterPercentText;
	public GameObject GameManager;
	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {



		//WaterPercentText.text = WaterPercentCalculation+ "%";



	}


	void OnGUI()
	{
		int WaterPercentCalculation = (int)((GameManager.GetComponent<GameManager>().WaterPercent/ 48.75f)*100.0f);
		string WaterCalc = "Ship currently filled: " + WaterPercentCalculation + "%";


		GUI.Label(new Rect(10, 25, 250, 100), WaterCalc);

	}
}
