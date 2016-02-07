using UnityEngine;
using System.Collections;

public class WaterBehavior : MonoBehaviour {

    public float riseSpeed = 0.05f;
    public float maxLevel = 4.0f;
	public float dropSpeed = 0.05f;

	public float waterLevel;
	public GameObject sibling;
	public bool isRising;

	public int roomNum = 0;
	public char floorChar = "T";


	// Use this for initialization
	void Start () {
        waterLevel = transform.localScale.y;
		foreach (Transform child in transform.parent) 
		{
			if (child.name != this.name)
			{
				sibling = child.gameObject;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
        Rise();
		isRising = sibling.activeInHierarchy;
	}

    void Rise()
    {
        if (waterLevel < maxLevel && isRising)
        {
            waterLevel += riseSpeed;
            transform.localScale += new Vector3(0.0F, riseSpeed, 0.0F);
            transform.localPosition += new Vector3(0.0F, riseSpeed/2, 0.0F);

        }
		if (waterLevel > 0.0f && !isRising)
		{
			waterLevel -= dropSpeed;
			transform.localScale -= new Vector3(0.0F, dropSpeed, 0.0F);
			transform.localPosition -= new Vector3(0.0F, dropSpeed/2, 0.0F);
		}
        

    }


}
