using UnityEngine;
using System.Collections;
using UnityEngine.UI; //required when using UI elements

public class MortarControl : MonoBehaviour {

	public float angle_z = -45.0f;
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
    public Text distance;
    public GameObject[] Targets;
    private TextGui GuiV;
    private TextGui GuiY;
    private TextGui GuiZ;


    //for tracking previous inputs

    // Use this for initialization
    void Start () {
        shot_remains = false;
		start_position = this.transform.position;
		transform.RotateAround (start_position, Vector3.right, 90-angle_y);
        Targets = GameObject.FindGameObjectsWithTag("Target");
        distance = GameObject.Find("DistanceUI").GetComponentInChildren<Text>();
        GuiV = GameObject.Find("Velocity").GetComponentInChildren<TextGui>();
        GuiY = GameObject.Find("TextGuiY").GetComponentInChildren<TextGui>();
        GuiZ = GameObject.Find("TextGuiZ").GetComponentInChildren<TextGui>();
        power = GuiV.GuiText;
        ShowTargetInformation();

    }

    // distance to multiple targets
    void ShowTargetInformation()
    {
        foreach (GameObject target in Targets)
        {
            distance.text+= string.Format("Distance to Target: {0} \n",this.transform.position - target.transform.position );
        }

    }


    void FireProjectile()
    {
        shot_remains = true;
        launch_force.Set(0f,
                             90-angle_y,
		                 angle_z);
        Rigidbody projectileClone = (Rigidbody) Instantiate(projectile, transform.position, transform.localRotation);
        projectileClone.AddRelativeForce(launch_force.normalized * power, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        //Changed fire to F because space was causing selection of input field
        if (Input.GetKey(KeyCode.F) && shot_remains == false && IntroScript.intro_over && Player.freeze == true)
        {
            FireProjectile();
            
        }
    }

	//getting the data from inside the textbox

	void Update () {
        power = GuiV.GuiText;
        angle_y = GuiY.GuiText;
        angle_z = GuiZ.GuiText;
        if (angle_y <= max_y && angle_z <= max_z && angle_y >= min_y && angle_z >= min_z){

	        this.transform.rotation = Quaternion.identity;
		    transform.RotateAround (start_position, Vector3.forward, 90-angle_y);
		}
		else
		{
			print ("Invalid Input");
		}
	}
}
