using UnityEngine;
using System.Collections;
using System;

public class Settings : MonoBehaviour {

	public GUIText Title;
	public GUIText Sound;
	public GUIText VisualAsst;
	private float volume = 0.5f;
	private float volume1 = 0.5f;
	public bool visualAssist;

	// Use this for initialization
	void Start () {
		Title.text = "Settings";
		Sound.text = "Volume";
		VisualAsst.text = "Visual Assist";

		Title.fontSize= Mathf.Min(Mathf.FloorToInt(Screen.width * Title.fontSize/500), Mathf.FloorToInt(Screen.height * Title.fontSize/500));
		Sound.fontSize= Mathf.Min(Mathf.FloorToInt(Screen.width * Sound.fontSize/500), Mathf.FloorToInt(Screen.height * Sound.fontSize/500));
		VisualAsst.fontSize= Mathf.Min(Mathf.FloorToInt(Screen.width * VisualAsst.fontSize/500), Mathf.FloorToInt(Screen.height * VisualAsst.fontSize/500));

		volume = PlayerPrefs.GetFloat ("Volume");
		volume1 = volume;
		visualAssist = Convert.ToBoolean(PlayerPrefs.GetInt ("VisualAssist"));
	}
	
	// Update is called once per frame

	void Update() {
		//Debug.Log ("Volume = " + volume);
#if UNITY_ANDROID
		if (Input.GetKey (KeyCode.Escape)) {
			Application.LoadLevel("MainMenu");
		}
#endif
	}

	void OnGUI() {
		string OnOff;
		volume1 = GUI.HorizontalSlider (new Rect ((float)(Screen.width * 0.4), (float)(Screen.height * 0.425), 200, 30), volume1, 0.0f, 1.0f);
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
		if (GUI.Button (new Rect ((float)(Screen.width * 0.6), (float)(Screen.height * 0.49), 50, 50), OnOff)) {
			visualAssist = !visualAssist;	
			PlayerPrefs.SetInt("VisualAssist", Convert.ToInt32(visualAssist));	
			Debug.Log (visualAssist);
		}
	}
}
