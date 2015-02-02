using UnityEngine;
using System.Collections;

public class LevelSelection : MonoBehaviour {

	public int level;
	public GUITexture gui_buttonNext;
	public GUITexture gui_buttonPrevious;
	public GUIText gui_textLevel;


	// Use this for initialization
	void Start () {
		level = 1;
		gui_textLevel.text = "Level " + level;
		//PlayerPrefs.SetInt ("level", level);
	}
	
	// Update is called once per frame
	void Update () {

		#if UNITY_EDITOR
		bool click = Input.GetMouseButtonDown(0);
		Vector2 clickPos = Input.mousePosition;
		if (click){
			if (gui_buttonNext.HitTest(clickPos)) {
				// Next
				if (level < 3)
					level++;
				PlayerPrefs.SetInt ("level", level);
				Application.LoadLevel ("Game");
			}
			else if (gui_buttonPrevious.HitTest (clickPos)) {
				// Previous
				if (level > 1)
					level--;
			}
		}

		#elif UNITY_ANDROID
		// Multiple touches
		foreach (Touch touch in Input.touches)
		{
			if (gui_buttonNext.HitTest (touch.position)) {
				// Next
				if (touch.phase == TouchPhase.Ended) {
					// Start
					if (level < 3)
						level++;
					PlayerPrefs.SetInt ("level", level);
					Application.LoadLevel("Game");
				}
			}
			else if (gui_buttonPrevious.HitTest (touch.position)) {
				// Previous
				if (touch.phase == TouchPhase.Ended) {
					// Start
					if (level > 1)
						level--;
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

		gui_textLevel.text = "Level " + level;
	}
}
