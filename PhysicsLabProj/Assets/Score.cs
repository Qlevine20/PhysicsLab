using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	private InputField s_if;
	public string score;
	private string old_text;
	private string prev_score;


	void Start(){
		s_if = this.GetComponent<InputField> ();
		old_text = s_if.text;
		prev_score = score;
		s_if.text += score;
	}
	// Use this for initialization
	// Update is called once per frame
	void Update () {
		if (score != prev_score) {

			prev_score = score;
			s_if.text = old_text + score;

		}
	}
}
