
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	private Vector3 distance_to_player;
	private bool close_enough;
	private Camera player_c;
	private Camera mortar_c;
	private Camera currcam;
	private bool mort_view;
	private Camera TopDownCam;
	public static bool freeze;
	// Use this for initialization
	void Start () {
		freeze = false;
		mort_view = false;
		player_c = GameObject.Find ("FirstPersonCharacter").GetComponent<Camera> ();
		mortar_c = GameObject.Find ("MortCamera").GetComponent<Camera> ();
		currcam = player_c;
		TopDownCam = GameObject.Find ("TopDownCam").GetComponent<Camera> ();
		currcam = player_c;
		distance_to_player = this.transform.position - GameObject.FindGameObjectWithTag ("Mortar").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		distance_to_player = this.transform.position - GameObject.FindGameObjectWithTag ("Mortar").transform.position;
		
		
		if (Input.GetKeyDown (KeyCode.V)) {
			currcam.enabled = false;
			TopDownCam.enabled = true;
		} 
		if (Input.GetKeyUp (KeyCode.V))
		{
			currcam.enabled = true;
			TopDownCam.enabled = false;
			
		}
		
		if (distance_to_player.sqrMagnitude < 30) 
		{
			if (Input.GetKeyDown (KeyCode.X))
			{
				if (mort_view)
				{
					freeze = false;
					mort_view = false;
					mortar_c.enabled = false;
					foreach (GameObject cam in GameObject.FindGameObjectsWithTag("Camera"))
					{
						cam.GetComponent<Camera>().enabled = false;
					}
					player_c.enabled = true;
					currcam = player_c;
				}
				else
				{
					freeze = true;
					mort_view = true;
					player_c.enabled = false;
					mortar_c.enabled = true;
					currcam = mortar_c;
				}
			}
		} 
		
	}
}
