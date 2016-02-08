using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	private GameObject WinImage;
	private GameObject GameOverImage;

    private float Timer = 2.0f;

    public float maxWater = 39.0f;


    public GameObject PatchKit;
	public GameObject[] rooms;
	public GameObject[] allWater;
    public GameObject[] activeWater;

	public float WaterPercent = 0.0f;

	public bool winner = false;

    public bool gameOver = false;

    // Use this for initialization
    void Start()
    {

		//sets the win and lose screens to false
		WinImage = GameObject.Find("WinImage");
		WinImage.SetActive(false);
		GameOverImage = GameObject.Find("LoseImage");
		GameOverImage.SetActive(false);

		allWater = GameObject.FindGameObjectsWithTag ("Water");
		rooms = GameObject.FindGameObjectsWithTag ("Room");
		foreach (GameObject obj in rooms)
        {
			for (int i = 0; i < obj.transform.childCount; i++)
			{
				obj.transform.GetChild (i).gameObject.SetActive (false);
			}
        }
        //This would make the patch kits at the start
        // Instantiate(PatchKit, transform.position, transform.rotation);
		//Instantiate(PatchKit, transform.position-30, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

		//gets the water percentage in order to be passed to the textbox
		WaterPercent = calcTotalWater ();

		//checks if the player passed the time limit
		if (Time.time >= 300 && gameOver == false) {

			winner = true;
			WinImage.SetActive(true);


		}

		if (Timer < Time.time)
        { 

			int rng = (int)(Random.value * (float)rooms.Length);
			for (int i = 0; i < rooms[rng].transform.childCount; i++)
			{
				rooms [rng].transform.GetChild (i).gameObject.SetActive (true);
			}


            Timer = Time.time + 3; //This sets the timer 3 seconds into the future
        }

        gameOver = isGameOver(calcTotalWater());
    }

    float calcTotalWater()
    {
        float rtn = 0.0f;
        activeWater = GameObject.FindGameObjectsWithTag("Water");
        foreach (GameObject obj in activeWater)
        {
            rtn += obj.transform.localScale.y;
        }

        return rtn;
    }

	bool isGameOver(float f) //<-----------------------------------------------------------------------------------------
	{

		if (f >= maxWater && winner== false) {

			GameOverImage.SetActive (true);
			return true;
		} 
		else {
			return false;

		}
	}


}