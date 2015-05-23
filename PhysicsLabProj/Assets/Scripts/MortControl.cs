using UnityEngine;
using System.Collections;
using UnityEngine.UI; //required when using UI elements


[RequireComponent(typeof(AudioSource))]
public class MortControl : MonoBehaviour {

	private TextGui GuiV;
	private TextGui GuiY;
	private TextGui GuiZ;
    private bool Start;
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
        FPSCam = GameObject.Find("FirstPersonCharacter");
        Start = true;
        
	}

    void Counter(float length)
    {
        float count = 0.0f;
        while (count <= length)
        {
            count += Time.deltaTime;
            print(count);
        }
        
    }


	void ShowTargetInformation()
	{
		foreach (GameObject target in Targets)
		{
			distance.text+= string.Format("Distance to Target: {0} \n",this.transform.position - target.transform.position );
		}
		
	}

    void CameraTargetSnap()
    {
        foreach (GameObject target in Targets) 
        {
            FPSCam.gameObject.transform.position.Set(target.gameObject.transform.position.x + x_offset, 
                target.gameObject.transform.position.y + y_offset, 
                target.gameObject.transform.position.z + z_offset);
            Counter(count_time);
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
        if (Start) 
        {
            CameraTargetSnap();
            Start = false;
        }
        
	}
	// Update is called once per frame
	void Update () {
		power = GuiV.GuiText;
		input_y = GuiY.GuiText;
		input_z = GuiZ.GuiText;
		if (input_y <= max_y && input_z <= max_z && input_y >= min_y && input_z >= min_z && change) 
		{
			this.transform.rotation = Quaternion.Euler (-input_z,input_y,0.0f);

		} 

	
	}
}
