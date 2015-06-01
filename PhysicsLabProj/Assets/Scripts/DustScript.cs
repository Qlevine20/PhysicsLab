using UnityEngine;
using System.Collections;

public class DustScript : MonoBehaviour {
	public Vector3 dustPos;
	public Quaternion dustRot;

	// Use this for initialization
	void Start () {
		dustPos = this.transform.position;
		dustRot = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update(){
		this.transform.rotation = dustRot;

	}
	void FixedUpdate () {
		this.transform.position = new Vector3(GameObject.Find ("FirstPersonCharacter").transform.position.x, dustPos.y,GameObject.Find ("FirstPersonCharacter").transform.position.z);
	}
}
