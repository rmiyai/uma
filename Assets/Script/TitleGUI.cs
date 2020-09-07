using UnityEngine;
using System.Collections;

public class TitleGUI : MonoBehaviour {
	public GUIStyle msg;

	void OnGUI(){
		GUI.Label (new Rect (30, Screen.height -50, 100, 40), "音が出るので気をつけてください",msg);
		GUIStyle buttonStyle = new GUIStyle (GUI.skin.button);
		if (GUI.Button (new Rect (150, Screen.height /2, 200, 54), "ゲームスタート", buttonStyle)) {
			Application.LoadLevel("Main");
				}
	}
}
