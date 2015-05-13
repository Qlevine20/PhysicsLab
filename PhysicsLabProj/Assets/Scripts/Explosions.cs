using UnityEngine;
using System.Collections;

public class Explosions : MonoBehaviour {
	public float time_to_die;
	// Use this for initialization
	void Awake () {
		Destroy (this, time_to_die);
	}
}