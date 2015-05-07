using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextGui : MonoBehaviour {

	public float GuiText;
	private InputField InputF;
	private string new_str = "1.234";
    public float _default;
	void Start (){
        GuiText = _default;
		InputF = this.gameObject.GetComponent<InputField>();

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
                GuiText = _default;
            }
        }
	}
}