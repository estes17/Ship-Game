using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    private float Timer = 2.0f;// = 0.0f;

    public float maxWater = 39.0f; // <-----------------------------------------------------------------------------------


    public GameObject PatchKit;
    public GameObject[] cracks;
    public GameObject[] waterCubes;

    public GameObject[] activeWater; // <-----------------------------------------------------------------------------------

    public bool gameOver = false;

    // Use this for initialization
    void Start()
    {
        cracks = GameObject.FindGameObjectsWithTag("Crack");
        foreach (GameObject obj in cracks)
        {
            obj.SetActive(false);
        }

        waterCubes = GameObject.FindGameObjectsWithTag("Water");
        foreach (GameObject obj in waterCubes)
        {
            obj.SetActive(false);
        }
        //This would make the patch kits at the start
        Instantiate(PatchKit, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

        if (Timer < Time.time)
        { //This checks wether real time has caught up to the timer
          // Instantiate(Crack, transform.position, transform.rotation); //This spawns the cracks when time

            int i = (int)(Random.value * (float)cracks.Length);

            cracks[i].SetActive(true);
            string crackId = GetCrackId(cracks[i]);
            activateWater(crackId);

            Timer = Time.time + 3; //This sets the timer 3 seconds into the future
        }

        gameOver = isGameOver(calcTotalWater()); // <-----------------------------------------------------------------------------------------------------------
        //  */
    }

    string GetCrackId(GameObject other)
    {
        string rtn = other.ToString();
        rtn = rtn.TrimStart("Crack ".ToCharArray());
        //rtn = rtn.TrimEnd (" (UnityEngine.GameObject)".ToCharArray());
        return rtn;
    }

    void activateWater(string id)
    {
        string waterId;
        foreach (GameObject obj in waterCubes)
        {
            waterId = obj.ToString();
            waterId = waterId.TrimStart("Water Cube ".ToCharArray());
            //crackName = crackName.TrimEnd (" (UnityEngine.GameObject)".ToCharArray ());
            if (id.Equals(waterId))
                obj.SetActive(true);
        }
    }

    float calcTotalWater() //<-------------------------------------------------------------------------
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
        return f >= maxWater;
    }

}
