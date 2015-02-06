using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public bool isPause;
	public bool isSettings;
	public GUITexture gui_buttonResume;
	public GUITexture gui_buttonSettings;
	public GUITexture gui_buttonExit;
	public GUITexture gui_buttonBack;
	public GUITexture gui_background;
	public GUIText gui_textPause;
	public GUIText gui_textResume;
	public GUIText gui_textSettings;
	public GUIText gui_textLevel;
	public GUIText gui_textSound;
	public GUIText gui_textVisualAsst;

	// Use this for initialization
	void Start () {
		isPause = false;
		isSettings = false;
		gui_background.enabled = false;
		gui_textPause.enabled = false;
		//gui_buttonResume.enabled = false;
		//gui_buttonSettings.enabled = false;
		//gui_buttonExit.enabled = false;
		//gui_textResume.enabled = false;
		//gui_textSettings.enabled = false;
		//gui_textLevel.enabled = false;
		//gui_buttonBack.enabled = false;
		//gui_textPause.enabled = false;
		gui_textSound.enabled = false;
		gui_textVisualAsst.enabled = false;
		gui_textPause.text = "Paused";
		gui_textResume.text = "Resume";
		gui_textSettings.text = "Settings";
		gui_textLevel.text = "Level Select";
		gui_textSound.text = "Sound";
		gui_textVisualAsst.text = "Visual Assist";
		DisablePause ();
		DisableSettings ();
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_EDITOR
		bool click = Input.GetMouseButtonDown(0);
		Vector2 clickPos = Input.mousePosition;
		if (click){
			if (!isSettings)
			{
				if (gui_buttonResume.HitTest(clickPos)) {
					// Resume
					isPause = false;
				}
				else if (gui_buttonSettings.HitTest (clickPos)) {
					// Settings
					isSettings = true;
				}
				else if (gui_buttonExit.HitTest (clickPos)) {
					// Level selection
					Application.LoadLevel("LevelSelection");
				}
			}
			else if (isSettings)
			{
				if (gui_buttonBack.HitTest (clickPos))
				{
					isSettings = false;
				}
			}
		}
		
		#elif UNITY_ANDROID
		// Multiple touches
		foreach (Touch touch in Input.touches)
		{
			if (!isSettigns)
			{
				if (gui_buttonResume.HitTest (touch.position)) {
					// Resume
					if (touch.phase == TouchPhase.Ended) {
						isPause = false;
					}
				}
				else if (gui_buttonSettings.HitTest (touch.position)) {
					// Settings
					if (touch.phase == TouchPhase.Ended) {
						isSettings = true;
					}
				}
				else if (gui_buttonExit.HitTest (touch.position)) {
					// Level selection
					if (touch.phase == TouchPhase.Ended) {
						Application.LoadLevel("LevelSelection");
					}
				}
			}
			else if (isSettings)
			{
				if (gui_buttonBack.HitTest(touch.position)) {
					isSettings = false;
				}
			}
		}
		if (Input.GetKey (KeyCode.Escape)) {
			isPause = false;
		}
		
		#endif

		if (isPause) {
			DisableSettings();
			RenderMain ();
		}
		if (isSettings) {
			DisablePause();
			RenderSettings ();
		}
	}

	void RenderMain() {
		gui_buttonResume.enabled = true;
		gui_buttonSettings.enabled = true;
		gui_buttonExit.enabled = true;
		gui_textResume.enabled = true;
		gui_textSettings.enabled = true;
		gui_textLevel.enabled = true;
	}

	void RenderSettings() {
		gui_buttonBack.enabled = true;
		gui_textSound.enabled = true;
		gui_textVisualAsst.enabled = true;
	}

	void DisablePause() {
		gui_buttonResume.enabled = false;
		gui_buttonSettings.enabled = false;
		gui_buttonExit.enabled = false;
		gui_textResume.enabled = false;
		gui_textSettings.enabled = false;
		gui_textLevel.enabled = false;
		Debug.Log ("Pause false");
	}
	
	void DisableSettings() {
		gui_buttonBack.enabled = false;
		gui_textSound.enabled = false;
		gui_textVisualAsst.enabled = false;
		Debug.Log ("Settings false");
	}
}
