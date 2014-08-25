using UnityEngine;
using System.Collections;

public class DebugTest : MonoBehaviour {

	SpriteRenderer BG;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(GUI.Button(new Rect(0, 50, 80, 50), "BLAH")){
//			BG.sprite.name;
		}
	}
}
