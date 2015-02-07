using UnityEngine;
using System.Collections;

public class LevelSelection : MonoBehaviour {

	public int level;
	public GUITexture gui_buttonNext;
	public GUITexture gui_buttonPrevious;
	public GUIText gui_textLevel;
	public Texture2D level1;
	public Texture2D level2;
	public Texture2D level3;
	public GUITexture gui_buttonLevel;

	// Use this for initialization
	void Start () {
		level = 1;
		gui_textLevel.text = "Level " + level;
		//PlayerPrefs.SetInt ("level", level);
		gui_buttonLevel.texture = level1;
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
				//Application.LoadLevel ("Game");
			}

			else if (gui_buttonPrevious.HitTest (clickPos)) {
				// Previous
				if (level > 1)
					level--;
				PlayerPrefs.SetInt ("level", level);
			}

			else if (gui_buttonLevel.HitTest (clickPos)) {
				PlayerPrefs.SetInt ("level", level);
				if (level == 1)
					Application.LoadLevel ("Game");
				else if (level == 2)
					Application.LoadLevel ("Game");
				else if (level == 3)
					Application.LoadLevel ("Game");
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
				}
			}
			else if (gui_buttonPrevious.HitTest (touch.position)) {
				// Previous
				if (touch.phase == TouchPhase.Ended) {
					// Start
					if (level > 1)
						level--;
					PlayerPrefs.SetInt ("level", level);
				}
			}
			else if (gui_buttonLevel.HitTest (touch.position)) {
				PlayerPrefs.SetInt ("level", level);
				if (level == 1)
					Application.LoadLevel ("Game");
				else if (level == 2)
					Application.LoadLevel ("Game");
				else if (level == 3)
					Application.LoadLevel ("Game");
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
		switch (level) {
		case 1:
			gui_buttonLevel.texture = level1;
			break;
		case 2:
			gui_buttonLevel.texture = level2;
			break;
		case 3:
			gui_buttonLevel.texture = level3;
			break;
		}
	}
}
