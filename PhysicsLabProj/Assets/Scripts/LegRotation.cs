using UnityEngine;
using System.Collections;

public class LegRotation : MonoBehaviour {
	private Quaternion past_mort_rotation;
	private Quaternion new_mort_rotation;

	// Use this for initialization
	void Start () {
		past_mort_rotation = GameObject.Find ("Mortar").transform.rotation;
		new_mort_rotation = past_mort_rotation;
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		new_mort_rotation = GameObject.Find ("Mortar").transform.rotation;
		if (past_mort_rotation != new_mort_rotation && Input.GetKey(KeyCode.Return)) {
			transform.Rotate (-(new_mort_rotation.eulerAngles));
			new_mort_rotation = past_mort_rotation;


		}
		
	
	}
}
