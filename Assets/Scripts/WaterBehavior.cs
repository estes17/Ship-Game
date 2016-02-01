using UnityEngine;
using System.Collections;

public class WaterBehavior : MonoBehaviour {

    public float riseSpeed = 0.05f;
    public float maxLevel = 4.0f;
	public string idStr;

    private float waterLevel;
	private GameObject[] cracks;
	public bool isRising;


	// Use this for initialization
	void Start () {
		idStr = GetIdStr();
        waterLevel = transform.localScale.y;
		FindCracks();
	}
	
	// Update is called once per frame
	void Update () {
        Rise();
		isRising = CompareNames ();
		FindCracks ();
	}

	string GetIdStr()
	{
		string rtn = gameObject.ToString ();
		rtn = rtn.TrimStart ("Water Cube ".ToCharArray());
		//rtn = rtn.TrimEnd (" (UnityEngine.GameObject)".ToCharArray());
		return rtn;
	}

	void FindCracks()
	{
		cracks = GameObject.FindGameObjectsWithTag ("Crack");
	}

	bool CompareNames()
	{
		string crackName;
		foreach (GameObject crack in cracks)
		{
			crackName = crack.ToString ();
			crackName = crackName.TrimStart ("Crack ".ToCharArray ());
			//crackName = crackName.TrimEnd (" (UnityEngine.GameObject)".ToCharArray ());
			if (idStr.Equals (crackName))
				return true;
		}
		return false;
	}

    void Rise()
    {
        if (waterLevel < maxLevel && isRising)
        {
            waterLevel += riseSpeed;
            transform.localScale += new Vector3(0.0F, riseSpeed, 0.0F);
            transform.localPosition += new Vector3(0.0F, riseSpeed/2, 0.0F);

        }
        

    }


}
