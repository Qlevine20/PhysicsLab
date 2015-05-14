using UnityEngine;
using System.Collections;

public class Explosions : MonoBehaviour {
	public float time_to_die;
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, time_to_die);
	}
}