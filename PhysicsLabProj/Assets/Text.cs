using UnityEngine;
using UnityEditor;
using System.Collections;

public class Text : MonoBehaviour {

//	public static float FloatField(Rect position, GUIContent label, float value, GUIStyle style = EditorStyles.numberField);

	// Use this for initialization
	void Start () {
	
	}

	// Editor Script that multiplies the scale of the current selected GameObject 
	
//	class EditorGUIFloatField extends EditorWindow {
//		
//		var sizeMultiplier : float = 1;
//		
//		@MenuItem("Examples/Scale selected Object")
//		static function Init() {
//			var window = GetWindow(EditorGUIFloatField);
//			window.position = Rect(0, 0, 210, 30);
//			window.Show();
//		}
//		
//		function OnGUI() {
//			sizeMultiplier = EditorGUI.FloatField(Rect(3,3,150, 20),
//			                                      "Increase scale by:", 
//			                                      sizeMultiplier);
//			if(GUI.Button(Rect(160,3,45,20), "Scale!"))
//				Selection.activeTransform.localScale = 
//					Selection.activeTransform.localScale * sizeMultiplier;
//		}
//	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
