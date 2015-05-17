using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextGui : MonoBehaviour {

	public float GuiText;
    public float default_float;
    public string default_string;
    private InputField InputF = null;

    void Start (){
        GuiText = default_float;
		InputF = this.gameObject.GetComponent<InputField>();
        InputF.text = default_string;

        // Add listener to catch the submit (when set Submit button is pressed)
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        InputF.onEndEdit = se;
    }
    void Update()
    {
        if (GuiText == 0.0f)
        {
            GuiText = default_float;
        }
    }


    // function that checks when the input changes and is submitted
    private void SubmitName(string name)
    {
        float float_num;

        if (float.TryParse(name, out float_num))
        {
			GameObject.Find("Mortar").GetComponent <MortControl>().change = true;
            GuiText = float_num;
			GameObject.Find("Mortar").GetComponent <MortControl>().change = true;
        }
        else
        {
            GuiText = default_float;
        }
    }
}