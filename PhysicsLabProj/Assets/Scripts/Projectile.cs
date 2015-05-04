using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float power;
	public Vector3 launch_force;
	public bool shot;
	// Use this for initialization
	void Start () {
		shot = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.Space) && shot == false) {
			launch_force.Set(0.0f,
			                 90-(GameObject.Find ("Mortar").GetComponent<MortarControl>().angle_z),
			                 0.0f);
			this.gameObject.GetComponent<Rigidbody>().useGravity = true;
			//this.gameObject.GetComponent<Rigidbody>().AddForce (power*launch_force);
			this.gameObject.GetComponent<Rigidbody>().AddRelativeForce (launch_force*power);

			shot = true;
		}
	}
	
}
