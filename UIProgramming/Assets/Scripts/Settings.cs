using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

	private float SliderValue = 0.0f;
	public GUIText Title;
	public GUIText Sound;
	public GUIText VisualAsst;

	// Use this for initialization
	void Start () {
		Title.text = "Settings";
		Sound.text = "Sound";
		VisualAsst.text = "Visual Assist";
	}
	
	// Update is called once per frame

	void Update() {

	}

	void OnGui() {
		SliderValue = GUI.HorizontalSlider (new Rect (10, 10, 100, 30), SliderValue, 0.0f, 10.0f);
	}
}
