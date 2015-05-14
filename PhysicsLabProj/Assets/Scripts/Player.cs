using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Vector3 distance_to_player;
	private bool close_enough;
	// Use this for initialization
	void Start () {
		distance_to_player = this.transform.position - GameObject.FindGameObjectWithTag ("Mortar").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		distance_to_player = this.transform.position - GameObject.FindGameObjectWithTag ("Mortar").transform.position;

		if (distance_to_player.sqrMagnitude < 30) {
			print ("close enough");
		} else 
		{
			print ("far enough");
		}
	}
}
