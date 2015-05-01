using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextGui : MonoBehaviour {

	private float GuiText;
	private InputField InputF;
	private string new_str = "1.234";
	void Start (){
		InputF = GameObject.Find ("InputField").GetComponent<InputField>();

	}
	void LateUpdate(){


		if(Input.GetKey(KeyCode.Return)){
		new_str = InputF.text;
		
		float float_num;
		
		if (float.TryParse (new_str,out float_num)) {
			GuiText = float_num;
			}
	}

	}
}