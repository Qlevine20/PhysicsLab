using UnityEngine;
using System.Collections;

public class DustScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position = GameObject.Find ("FirstPersonCharacter").transform.position;
	}
}
