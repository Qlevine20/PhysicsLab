using UnityEngine;
using System.Collections;
using UnityEngine.UI; //required when using UI elements

public class MortarControl : MonoBehaviour {

	public float angle_z = 45.0f;
	public float angle_y = 0.0f;
	public Vector3 start_force;
	public InputField input_y;
	public InputField input_z;


	//for tracking previous inputs
	private string prev_y;
	private string prev_z;

	// Use this for initialization
	void Start () {
		prev_y = input_y.text;
		prev_z = input_z.text;
	}

	//getting the data from inside the textbox

	void LateUpdate () {
		if ((input_y.text != prev_y || input_z.text != prev_z) && Input.GetKey(KeyCode.Return)) {
			angle_y = (input_y.gameObject.GetComponent<TextGui>().GuiText);
			angle_z = (input_z.gameObject.GetComponent<TextGui>().GuiText);
			transform.Rotate (new Vector3 (0.0f, angle_y, angle_z));
			prev_y = input_y.text;
			prev_z = input_z.text;
		}
	}


}
