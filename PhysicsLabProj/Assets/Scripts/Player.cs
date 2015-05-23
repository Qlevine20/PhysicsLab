using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Vector3 distance_to_player;
	private bool close_enough;
	private Camera player_c;
	private Camera mortar_c;
	private bool mort_view;
	public static bool freeze;
	// Use this for initialization
	void Start () {
		freeze = false;
		mort_view = false;
		player_c = GameObject.Find ("FirstPersonCharacter").GetComponent<Camera> ();
		mortar_c = GameObject.Find ("MortarCam").GetComponent<Camera> ();
		distance_to_player = this.transform.position - GameObject.FindGameObjectWithTag ("Mortar").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		distance_to_player = this.transform.position - GameObject.FindGameObjectWithTag ("Mortar").transform.position;

		if (distance_to_player.sqrMagnitude < 30) {
			if (Input.GetKeyDown (KeyCode.X))
			{
				if (mort_view)
				{
					freeze = false;
					mort_view = false;
					mortar_c.enabled = false;
					player_c.enabled = true;
				}
				else
				{
					freeze = true;
					mort_view = true;
					player_c.enabled = false;
					mortar_c.enabled = true;
				}
			}
		} 
		
	}
}
