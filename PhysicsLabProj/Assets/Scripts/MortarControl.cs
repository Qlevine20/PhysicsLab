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
    public bool shot_remains;
    public Rigidbody projectile;
    public float power;
    public Vector3 launch_force;


    //for tracking previous inputs
    private string prev_y;
	private string prev_z;

	// Use this for initialization
	void Start () {
        shot_remains = false;
		start_position = this.transform.position;
		prev_y = input_y.text;
		prev_z = input_z.text;
		transform.RotateAround (start_position, Vector3.forward, 90-angle_z);
	}


    void FireProjectile()
    {
        shot_remains = true;
        launch_force.Set(0.0f,
                             90 - angle_z,
                             0.0f);
        Rigidbody projectileClone = (Rigidbody) Instantiate(projectile, transform.position, transform.rotation);
        projectileClone.AddRelativeForce(launch_force.normalized * power, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && shot_remains == false)
        {
            FireProjectile();
            
        }
    }

	//getting the data from inside the textbox

	void LateUpdate () {
		if ((input_y.text != prev_y || input_z.text != prev_z) && Input.GetKey(KeyCode.Return)) {

			angle_y = 180+(input_y.gameObject.GetComponent<TextGui>().GuiText);
			angle_z = (input_z.gameObject.GetComponent<TextGui>().GuiText);
			if (angle_y <= max_y && angle_z <= max_z && angle_y >= min_y && angle_z >= min_z){

			    this.transform.rotation = Quaternion.identity;
				transform.RotateAround (start_position, Vector3.forward, 90-angle_z);
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
