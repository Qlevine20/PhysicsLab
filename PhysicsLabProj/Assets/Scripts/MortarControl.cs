using UnityEngine;
using System.Collections;
using UnityEngine.UI; //required when using UI elements

public class MortarControl : MonoBehaviour {

	public float angle_z = 45.0f;
	public float angle_y = 0.0f;
	public float max_y = 90.0f;
	public float max_z = 90.0f;
	public float min_y = 0.0f;
	public float min_z = 0.0f;
	public Vector3 start_force;
	public InputField input_y;
	public InputField input_z;
	private Vector3 start_position;


	//for tracking previous inputs
	private string prev_y;
	private string prev_z;

	// Use this for initialization
	void Start () {
		start_position = this.transform.position;
		prev_y = input_y.text;
		prev_z = input_z.text;
		transform.RotateAround (start_position, Vector3.zero, 90-angle_z);
	}

	//getting the data from inside the textbox

	void LateUpdate () {
		if ((input_y.text != prev_y || input_z.text != prev_z) && Input.GetKey(KeyCode.Return)) {

			angle_y = (input_y.gameObject.GetComponent<TextGui>().GuiText);
			angle_z = (input_z.gameObject.GetComponent<TextGui>().GuiText);
			if (angle_y <= max_y && angle_z <= max_z && angle_y >= min_y && angle_z >= min_z){

			this.transform.rotation = Quaternion.identity;
				transform.RotateAround (start_position, Vector3.zero, 90-angle_z);
			prev_y = input_y.text;
			prev_z = input_z.text;
			}
			else
			{
				print ("Invalid Input");
			}
		}
	}

}
