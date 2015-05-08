using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextGui : MonoBehaviour {

	public float GuiText;
	private InputField InputF;
	private string new_str = "1.234";
    public float default_float;
    public string default_string;
	void Start (){
        GuiText = default_float;
		InputF = this.gameObject.GetComponent<InputField>();
        InputF.text = default_string;

	}
	void Update(){

		if (InputF.isFocused) {
				new_str = InputF.text;
		
				float float_num;

            if (float.TryParse(new_str, out float_num))
            {
                GuiText = float_num;
            }
            else
            {
                GuiText = default_float;
            }
        }
	}
}