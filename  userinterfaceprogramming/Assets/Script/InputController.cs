using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public GameObject target;
	public GameObject DebugLog;
	
	public GUITexture gui_buttonPlay;
	public GUITexture gui_buttonSettings;
	public GUITexture gui_buttonCredits;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		#if UNITY_ANDROID
		// Multiple touches
		foreach (Touch touch in Input.touches)
		{
			if (gui_buttonPlay.HitTest(touch.position)) 
			{
				if (touch.phase == TouchPhase.Ended) {
					// Start
				}	
			}
			else if (gui_buttonSettings.HitTest (touch.position))
			{
				if (touch.phase == TouchPhase.Ended) {
					// Settings
				}	
			}
			else if (gui_buttonCredits.HitTest(touch.position)) {
				if (touch.phase == TouchPhase.Ended) {
					// Credits
				}
			}
		}
		#endif
		
		#if UNITY_EDITOR
		bool click = Input.GetMouseButton(0);
		Vector2 clickPos = Input.mousePosition;
		if (click){
			if (gui_buttonPlay.HitTest(clickPos)) {
				// Start
			}
			else if (gui_buttonSettings.HitTest (clickPos)) {
				// Settings
			}
			else if (gui_buttonCredits.HitTest (clickPos)) {
				// Credits
			}
		}
		
		#endif
	}
}
