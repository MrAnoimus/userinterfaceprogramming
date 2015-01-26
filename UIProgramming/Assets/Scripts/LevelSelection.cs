using UnityEngine;
using System.Collections;

public class LevelSelection : MonoBehaviour {

	public GUITexture gui_buttonNext;
	public GUITexture gui_buttonPrevious;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID
		// Multiple touches
		foreach (Touch touch in Input.touches)
		{
			if (gui_buttonNext.HitTest (touch.position)) {
				// Next
				if (touch.phase == TouchPhase.Ended) {
					// Start
					Application.LoadLevel ("Game");
					
				}
			}
			else if (gui_buttonPrevious.HitTest (touch.position)) {
				// Previous
				if (touch.phase == TouchPhase.Ended) {
					// Start
					
				}
			}
		}
		if (Input.GetKey (KeyCode.Escape)) {
			if (Application.loadedLevelName != "MainMenu") {
				Application.LoadLevel("MainMenu");
			}
			else {
				Application.Quit ();
			}
		}
		#endif
		
		#if UNITY_EDITOR
		bool click = Input.GetMouseButton(0);
		Vector2 clickPos = Input.mousePosition;
		if (click){
			if (gui_buttonNext.HitTest(clickPos)) {
				// Next
				Application.LoadLevel ("Game");
			}
			else if (gui_buttonPrevious.HitTest (clickPos)) {
				// Previous
			}
		}
		#endif
	}
}
