using UnityEngine;
using System.Collections;
using UnityEngine.UI; //required when using UI elements


[RequireComponent(typeof(AudioSource))]
public class MortControl : MonoBehaviour {
	
	private TextGui GuiV;
	private TextGui GuiY;
	private TextGui GuiZ;
	public Text distance;
	public GameObject[] Targets;
	public Rigidbody projectile;
	public Vector3 launch_force;
	public float max_y = 89.0f;
	public float max_z = 90.0f;
	public float min_y = 0.0f;
	public float min_z = 0.0f;
	public float power;
	public float input_y;
	public float input_z;
	public bool mort;
	public bool change;
	public float count_time; // used in Counter() to determine the length of time to wait
	public AudioClip fire;
	private GameObject FPSCam;
	public GameObject FPSCon;
	private bool fin;
	private float start_count;
	private bool start_finished;
	
	
	//Camera Offset - set the values for camera offset
	public float x_offset;
	public float y_offset;
	public float z_offset;
	
	
	
	
	
	
	// Use this for initialization
	void Awake () {
		mort = true;
		Targets = GameObject.FindGameObjectsWithTag("Target");
		distance = GameObject.Find("DistanceUI").GetComponentInChildren<Text>();
		GuiY = GameObject.Find ("TextGuiY").GetComponent<TextGui> ();
		GuiZ = GameObject.Find ("TextGuiZ").GetComponent<TextGui> ();
		GuiV = GameObject.Find ("Velocity").GetComponent<TextGui> ();
		power = GuiV.GuiText;
		input_y = GuiY.GuiText;
		input_z = GuiZ.GuiText;
		this.transform.rotation = Quaternion.Euler (-input_z,input_y,0.0f);
		ShowTargetInformation();
		FPSCam = GameObject.Find("StartCam");
		fin = false;
		start_count = 0.0f;
		start_finished = true;
		
	}
	
	void Start()
	{
		foreach (GameObject target in Targets) {
			StartCoroutine(CamMove (count_time,target)); 
			print ("run");
			
		}
	}
	void ShowTargetInformation()
	{
		foreach (GameObject target in Targets)
		{
			distance.text+= string.Format("Distance to Target: {0} \n",this.transform.position - target.transform.position );
		}
		
	}
	
	void FireProjectile()
	{
		AudioSource.PlayClipAtPoint(fire,this.transform.position) ;
		launch_force = Vector3.forward;
		Rigidbody projectileClone = (Rigidbody) Instantiate(projectile, transform.position, transform.localRotation);
		projectileClone.AddRelativeForce(launch_force.normalized * power, ForceMode.Impulse);
	}
	
	void FixedUpdate()
	{
		//Changed fire to F because space was causing selection of input field
		if (Input.GetKey(KeyCode.F) && IntroScript.intro_over && Player.freeze == true && mort)
		{
			mort = false;
			FireProjectile();
			
		}
		
		
	}
	
	IEnumerator Timer()
	{
		yield return new WaitForSeconds(count_time);
		start_count += 1.0f;
		
		
	}
	
	
	
	IEnumerator CamMove(float waitTime,GameObject target)
	{

		FPSCam.gameObject.transform.position = new Vector3 (target.gameObject.transform.position.x + x_offset, 
		                                                    target.gameObject.transform.position.y + y_offset, 
		                                                    target.gameObject.transform.position.z + z_offset);

		print ("here");
		yield return new WaitForSeconds(waitTime);
		print ("there");
		start_count += 1;
	}
	// Prints your numbers, waits!
	
	// Update is called once per frame
	void Update () {
		power = GuiV.GuiText;
		input_y = GuiY.GuiText;
		input_z = GuiZ.GuiText;
		if (input_y <= max_y && input_z <= max_z && input_y >= min_y && input_z >= min_z && change) 
		{
			this.transform.rotation = Quaternion.Euler (-input_z,input_y,0.0f);
			
		}
		
		
		if (start_count >= Targets.Length && start_finished){
			start_finished = false;
			FPSCon.SetActive (true);
			FPSCam.SetActive (false);

		}
		
	}
}
