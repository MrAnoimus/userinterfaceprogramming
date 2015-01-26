using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public GameObject target;
	public GameObject DebugLog;

	public AudioClip[] AudioClips; 
	public GUITexture gui_buttonPlay;
	public GUITexture gui_buttonSettings;
	public GUITexture gui_buttonCredits;
	public GUITexture gui_buttonNext;
	public GUITexture gui_buttonPrevious;

	string lastLevel;

	// Use this for initialization
	void Start () {

	}
	void PlaySound(int selection)
	{
		audio.clip = AudioClips [selection];
		audio.Play();
	}
	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID
		// Multiple touches
		foreach (Touch touch in Input.touches)
		{
			if (gui_buttonPlay.HitTest(touch.position)) 
			{
				PlaySound(0);
				if (touch.phase == TouchPhase.Ended) {
					// Start
					Application.LoadLevel ("LevelSelect");
				}	
			}
			else if (gui_buttonSettings.HitTest (touch.position))
			{
				PlaySound(0);
				if (touch.phase == TouchPhase.Ended) {
					// Settings
					Application.LoadLevel ("Settings");
				}	
			}
			else if (gui_buttonCredits.HitTest(touch.position)) {
				PlaySound(0);
				if (touch.phase == TouchPhase.Ended) {
					// Credits
					Application.LoadLevel ("Credits");
				}
			}
			else if (gui_buttonNext.HitTest (touch.position)) {
				// Next
				PlaySound(0);
			}
			else if (gui_buttonPrevious.HitTest (touch.position)) {
				// Previous
				PlaySound(0);
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
			if (gui_buttonPlay.HitTest(clickPos)) {
				// Start
				Application.LoadLevel ("LevelSelect");
			}
			else if (gui_buttonSettings.HitTest (clickPos)) {
				// Settings
				Application.LoadLevel ("Settings");
			}
			else if (gui_buttonCredits.HitTest (clickPos)) {
				// Credits
				PlaySound(0);
				Application.LoadLevel ("Credits");
			}
			else if (gui_buttonNext.HitTest(clickPos)) {
				// Next
			}
			else if (gui_buttonPrevious.HitTest (clickPos)) {
				// Previous
			}
		}
		#endif
	}
}
