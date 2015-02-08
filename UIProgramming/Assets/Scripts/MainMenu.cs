using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public AudioClip[] AudioClips; 

	// Use this for initialization
	void Start () {
		PlaySound (0);

		
		if (!PlayerPrefs.HasKey("Volume")){
			PlayerPrefs.SetFloat("Volume", 0.5f);
			Debug.Log ("test");
		}
		if (!PlayerPrefs.HasKey("VisualAssist")){
			PlayerPrefs.SetInt("VisualAssist", 0);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void PlaySound(int selection)
	{
		audio.clip = AudioClips [selection];
		audio.Play();
	}
}
