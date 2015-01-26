using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

	private float SliderValue = 0.0f;
	public GUIStyle slider;
	public GUIStyle thumb;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGui() {
		SliderValue = GUI.HorizontalSlider (new Rect (25, 25, 100, 30), SliderValue, 0.0f, 10.0f, slider, thumb);
	}
}
