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
	public float max_y = 360.0f;
	public float max_z = 90.0f;
	public float min_y = -360.0f;
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
	private bool start_finished;
	public int shot_count;
	private GameObject currmort;





	//Mortar Rotation Objects
	public GameObject MortarMin;
	public GameObject MortarOverMin;
	public GameObject MortarUnderMid;
	public GameObject MortarMid;
	public GameObject MortarOverMid;
	public GameObject MortarUnderMax;
	public GameObject MortarMax;

	//Camera Offset - set the values for camera offset
	public float x_offset;
	public float y_offset;
	public float z_offset;

	
	
	
	
	
	
	// Use this for initialization
	void Awake () {
		currmort = MortarMid;
		shot_count = 0;
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
		start_finished = true;
		FPSCam.transform.position = new Vector3 (Targets [0].transform.position.x + x_offset,
            Targets [0].transform.position.y + y_offset,
            Targets [0].transform.position.z + z_offset);
		
	}
	
	void Start()
	{
		StartCoroutine (ExecuteIndefinitely ());
			
		}
	public void ShowTargetInformation()
	{
		foreach (GameObject target in Targets)
		{
			distance.text+= string.Format("{0}: {1} \n",target.gameObject.name,this.transform.position - target.transform.position );
		}
		
	}
	
	void FireProjectile()
	{
		shot_count = 1;
		AudioSource.PlayClipAtPoint(fire,this.transform.position) ;
		launch_force = new Vector3 (0.0f, input_z/90, 1 - (input_z/360));
		print (launch_force);
		Rigidbody projectileClone = (Rigidbody) Instantiate(projectile, transform.position, transform.localRotation);
		projectileClone.AddRelativeForce(launch_force * power, ForceMode.Impulse);
	}
	
	void FixedUpdate()
	{
		//Changed fire to F because space was causing selection of input field
		if (Input.GetKey(KeyCode.F) && IntroScript.intro_over && Player.freeze == true && shot_count == 0)
		{
			mort = false;
			FireProjectile();
			
		}
		
		
	}
	
	
	IEnumerator ExecuteIndefinitely()
	{   
		int ind = 0;
		while (true)
		{   
			if (ind == Targets.Length)
			{
				break;
			}
			else
			{
				GameObject target = Targets[ind];
			FPSCam.gameObject.transform.position = new Vector3 (target.gameObject.transform.position.x + x_offset, 
			                                                    target.gameObject.transform.position.y + y_offset, 
			                                                    target.gameObject.transform.position.z + z_offset);
				ind +=1;
			yield return new WaitForSeconds(count_time);
			}
		}   
	} 
	

	// Update is called once per frame
	void Update () {
		power = GuiV.GuiText;
		input_y = GuiY.GuiText;
		input_z = GuiZ.GuiText;
		if (input_y <= max_y && input_z <= max_z && input_y >= min_y && input_z >= min_z && change) 
			//		{
						this.transform.rotation = Quaternion.Euler (0.0f,input_y,0.0f);
			//			
			//		}


		if (20 > input_z && input_z >= 0)
		{
			currmort.SetActive(false);
			MortarMin.SetActive (true);
			currmort = MortarMin;
		}

		if (30 > input_z && input_z >= 20)
		{
			currmort.SetActive(false);
			MortarOverMin.SetActive (true);
			currmort = MortarOverMin;
		}

		if (40 > input_z && input_z >= 30)
		{
			currmort.SetActive(false);
			MortarUnderMid.SetActive (true);
			currmort = MortarUnderMid;
		}


		
		if (50 > input_z && input_z >= 40)
		{
			currmort.SetActive(false);
			MortarMid.SetActive (true);
			currmort = MortarMid;
		}

		if (60 > input_z && input_z >= 50)
		{
			currmort.SetActive(false);
			MortarOverMid.SetActive (true);
			currmort = MortarOverMid;
		}

		if (70 > input_z && input_z >= 60)
		{
			currmort.SetActive(false);
			MortarUnderMax.SetActive (true);
			currmort = MortarUnderMax;
		}

		if (81 > input_z && input_z >= 70)
		{
			currmort.SetActive(false);
			MortarMax.SetActive (true);
			currmort = MortarMax;
		}
//		

		if (Time.time >= Targets.Length*count_time && start_finished){
			start_finished = false;
			FPSCon.SetActive (true);
			FPSCam.SetActive (false);

		}
		
	}
}
