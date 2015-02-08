using UnityEngine;
using System.Collections;
using System;

public class PauseMenu : MonoBehaviour {

	public Game game;
	public bool isPause;
	public bool isSettings;
	public GUITexture gui_buttonResume;
	public GUITexture gui_buttonSettings;
	public GUITexture gui_buttonExit;
	public GUITexture gui_buttonBack;
	public GUITexture gui_background;
	public GUIText gui_textTitle;
	public GUIText gui_textResume;
	public GUIText gui_textSettings;
	public GUIText gui_textLevel;
	public GUIText gui_textSound;
	public GUIText gui_textVisualAsst;
	public GUIText gui_textBack;
	public GameObject Results;
	private float volume = 0.5f;
	private float volume1 = 0.5f;
	public bool visualAssist;
	// Use this for initialization
	void Start () {
		isPause = game.GetComponent<Game>().Pause;
		isSettings = false;
		gui_background.enabled = false;
		gui_textTitle.enabled = false;
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
		gui_textTitle.text = "Paused";
		gui_textResume.text = "Resume";
		gui_textSettings.text = "Settings";
		gui_textLevel.text = "Level Select";
		gui_textSound.text = "Sound";
		gui_textVisualAsst.text = "Visual Assist";
		gui_textBack.text = "Back";
		DisablePause ();
		DisableSettings ();
		volume = PlayerPrefs.GetFloat ("Volume");
		volume1 = volume;
		visualAssist = Convert.ToBoolean(PlayerPrefs.GetInt ("VisualAssist"));

		gui_textTitle.fontSize= Mathf.Min(Mathf.FloorToInt(Screen.width * gui_textTitle.fontSize/500), Mathf.FloorToInt(Screen.height * gui_textTitle.fontSize/500));
		gui_textResume.fontSize= Mathf.Min(Mathf.FloorToInt(Screen.width * gui_textResume.fontSize/500), Mathf.FloorToInt(Screen.height * gui_textResume.fontSize/500));
		gui_textSettings.fontSize= Mathf.Min(Mathf.FloorToInt(Screen.width * gui_textSettings.fontSize/500), Mathf.FloorToInt(Screen.height * gui_textSettings.fontSize/500));
		gui_textSound.fontSize= Mathf.Min(Mathf.FloorToInt(Screen.width * gui_textSound.fontSize/500), Mathf.FloorToInt(Screen.height * gui_textSound.fontSize/500));
		gui_textVisualAsst.fontSize= Mathf.Min(Mathf.FloorToInt(Screen.width * gui_textVisualAsst.fontSize/500), Mathf.FloorToInt(Screen.height * gui_textVisualAsst.fontSize/500));
		gui_textLevel.fontSize= Mathf.Min(Mathf.FloorToInt(Screen.width * gui_textLevel.fontSize/500), Mathf.FloorToInt(Screen.height * gui_textLevel.fontSize/500));
		gui_textVisualAsst.fontSize= Mathf.Min(Mathf.FloorToInt(Screen.width * gui_textVisualAsst.fontSize/500), Mathf.FloorToInt(Screen.height * gui_textVisualAsst.fontSize/500));
		gui_textBack.fontSize= Mathf.Min(Mathf.FloorToInt(Screen.width * gui_textBack.fontSize/500), Mathf.FloorToInt(Screen.height * gui_textBack.fontSize/500));
	}
	
	// Update is called once per frame
	void Update () {
		isPause = game.GetComponent<Game>().Pause;
		#if UNITY_EDITOR
		bool click = Input.GetMouseButtonDown(0);
		Vector2 clickPos = Input.mousePosition;
		if (click){
			if(Results.GetComponent<Results>().EndOfLevel==false)
			{
			if (isPause)
			{
				if (!isSettings)
				{
					if (gui_buttonResume.HitTest(clickPos)) {
						// Resume
						isPause = false;
						game.GetComponent<Game>().Pause = false;
					}
					else if (gui_buttonSettings.HitTest (clickPos)) {
						// Settings
						isSettings = true;
					}
					else if (gui_buttonExit.HitTest (clickPos)) {
						// Level selection
						Application.LoadLevel("LevelSelect");
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
		}
		}
		
		#elif UNITY_ANDROID

		// Multiple touches
		foreach (Touch touch in Input.touches)
		{
			if(Results.GetComponent<Results>().EndOfLevel==false)
			{
			if (isPause)
			{
				if (!isSettings)
				{
					if (gui_buttonResume.HitTest (touch.position)) {
						// Resume
						if (touch.phase == TouchPhase.Ended) {
							isPause = false;
							game.GetComponent<Game>().Pause = false;
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
							Application.LoadLevel("LevelSelect");
						}
					}
				}
				else if (isSettings)
				{
					if (gui_buttonBack.HitTest(touch.position)) {
						if (touch.phase == TouchPhase.Ended) {
							isSettings = false;
						}
					}
				}
			}
		}
		}
		if (Input.GetKey (KeyCode.Escape)) {
			isPause = false;
		}

		#endif

		if (isPause) {
			gui_background.enabled = true;
			if (!isSettings) {
				DisableSettings();
				RenderMain ();
			}
			else {
				DisablePause();
				RenderSettings ();
			}
		} 
		else {
			gui_background.enabled = false;
			DisablePause();
		}

	}

	void RenderMain() {
		gui_textTitle.text = "Paused";
		gui_buttonResume.enabled = true;
		gui_buttonSettings.enabled = true;
		gui_buttonExit.enabled = true;
		gui_textTitle.enabled = true;
		gui_textResume.enabled = true;
		gui_textSettings.enabled = true;
		gui_textLevel.enabled = true;
	}

	void RenderSettings() {
		gui_textTitle.text = "Settings";
		gui_buttonBack.enabled = true;
		gui_textSound.enabled = true;
		gui_textVisualAsst.enabled = true;
		gui_textBack.enabled = true;
	}

	void DisablePause() {
		gui_buttonResume.enabled = false;
		gui_buttonSettings.enabled = false;
		gui_buttonExit.enabled = false;
		gui_textTitle.enabled = false;
		gui_textResume.enabled = false;
		gui_textSettings.enabled = false;
		gui_textLevel.enabled = false;
		//Debug.Log ("Pause false");
	}
	
	void DisableSettings() {
		gui_buttonBack.enabled = false;
		gui_textSound.enabled = false;
		gui_textVisualAsst.enabled = false;
		gui_textBack.enabled = false;
		//Debug.Log ("Settings false");
	}

	void OnGUI() {
		if (isSettings) {
			string OnOff;
			volume1 = GUI.HorizontalSlider (new Rect ((float)(Screen.width * 0.375), (float)(Screen.height * 0.44), 200, 30), volume1, 0.0f, 1.0f);
			if (volume != volume1) {
				volume = volume1;
				PlayerPrefs.SetFloat("Volume", volume);
			}
			if (visualAssist == true) 
			{
				OnOff="On";
			}
			else{
				OnOff="Off";
			}
			if (GUI.Button (new Rect ((float)(Screen.width * 0.6), (float)(Screen.height * 0.5), 50, 50), OnOff)) {
				visualAssist = !visualAssist;	
				PlayerPrefs.SetInt("VisualAssist", Convert.ToInt32(visualAssist));	
				//Debug.Log (visualAssist);
			}
		}
	}
}
