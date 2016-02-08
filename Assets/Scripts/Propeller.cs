using UnityEngine;
using System.Collections;

public class Propeller : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, -18, 0) * Time.deltaTime);
	}
}
