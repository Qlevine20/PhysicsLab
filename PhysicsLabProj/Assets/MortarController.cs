using UnityEngine;
using System.Collections;
using UnityEngine.UI; //required when using UI elements

public class MortarController : MonoBehaviour {

	public float angle_z = 45.0f;
	public float angle_y = 0.0f;
	public Vector3 start_force;
	public InputField input_y;
	public InputField input_z;

	//for tracking previous inputs
	private InputField prev_y;
	private InputField prev_z;

	// Use this for initialization
	void Start () {
//		prev_y = input_y;
//		prev_z = input_z;
	}

	//getting the data from inside the textbox
	void Update() {
//		input_y.text = "Enter Text Here...";
//		input_z.text = "Enter Text Here...";

	}


	void FixedUpdate () {
//		if (input_y != prev_y || input_z != prev_z) {
//			angle_y = float.Parse(input_y);
//			angle_z = float.Parse (input_z);
//			transform.Rotate (new Vector3 (0.0f, angle_y, angle_z));
//		}
	}


}
