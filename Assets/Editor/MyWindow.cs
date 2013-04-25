using UnityEditor;
using UnityEngine;
using System.Collections;

public class MyWindow : EditorWindow {
	float objMass = 1.00f;
	
	[MenuItem ("MyWindow/DoSomething")]
	static void DoSomething() {
		Debug.Log ("I did something");
	}
	
	[MenuItem ("MyWindow/Rigidbody/Double Mass")]
    static void DoubleMass () {
        GameObject body = Selection.gameObjects[0];
		if (body.GetComponent<Rigidbody>() == null){
			body.AddComponent<Rigidbody>();
		}
        body.rigidbody.mass = body.rigidbody.mass * 2;
        Debug.Log ("Doubled Rigidbody's Mass to " + body.rigidbody.mass + " from Context Menu.");
    }
	
	[MenuItem ("Window/MyWindow")]
	public static void ShowWindow(){
		EditorWindow.GetWindow(typeof(MyWindow));	
	}

	void OnGUI(){
		GUILayout.Label ("Set object mass",EditorStyles.boldLabel);
		objMass = EditorGUILayout.Slider("Slider", objMass, 1, 100);
		if (Selection.activeObject == null){
			Debug.Log ("Select an object");
		}
		else{
			GameObject body = Selection.gameObjects[0];
			if (body.GetComponent<Rigidbody>() == null){
				body.AddComponent<Rigidbody>();
			}
		body.rigidbody.mass = objMass;
		Debug.Log("Rigidbody mass altered to " + body.rigidbody.mass);
		}	
	}
}
