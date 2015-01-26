using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public AudioClip[] AudioClips; 
	// Use this for initialization
	void Start () {
		PlaySound (0);
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
