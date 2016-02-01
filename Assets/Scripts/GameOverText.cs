using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverText : MonoBehaviour {

    public Text ItsGameOverText;
    public GameObject GameManager;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (GameManager.GetComponent<GameManager>().gameOver == true)
        {

            ItsGameOverText.text = "GAME OVER";


        }
 
    }
}
