using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class Tutorial : MonoBehaviour {

	

	int tutorialmsg=0;
	public GUIText[] Tutorials;
	public GameObject[] Arrows;
	public bool tutorialover;
	public SpriteRenderer[] Sprites;
	Matrix4x4 matrix;
	GUIStyle guiStyle;
	// Use this for initialization

	void Start () {
		Load ();
		for(int i=0; i < 6; i++)
		{
			Tutorials[i].fontSize= Mathf.Min(Mathf.FloorToInt(Screen.width * Tutorials[i].fontSize/500), Mathf.FloorToInt(Screen.height * Tutorials[i].fontSize/500));
		}
		//matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, Vector3(Screen.width/virtualWidth, Screen.height/virtualHeight, 1.0));
		for(int i=0; i < 6; i++)
		{
			Tutorials[i].guiText.enabled=false;

		}
		for(int i=0; i < 5; i++)
		{
			Arrows[i].SetActive(false);
			
		}

	}

	// Update is called once per frame
	void Update () {

		if (tutorialover == false) {
						Debug.Log ("MsgCounter: " + tutorialmsg);
						if (tutorialmsg == 1) {
								Tutorials [0].enabled = true;
								Tutorials [1].enabled = true;
								Arrows [1].SetActive (true);
								
						} else if (tutorialmsg == 2) {
								Tutorials [0].enabled = false;
								Tutorials [1].enabled = false;
								Tutorials [2].enabled = true;
								Tutorials [3].enabled = true;
								Arrows [2].SetActive (true);
								Arrows [1].SetActive (false);
								Arrows [0].SetActive (true);
						} else if (tutorialmsg == 3) {
								Tutorials [2].enabled = false;
								Tutorials [3].enabled = false;
								Tutorials [4].enabled = true;
								Tutorials [5].enabled = true;
								Arrows [0].SetActive (false);
								Arrows [2].SetActive (false);
								Arrows [3].SetActive (true);
								Arrows [4].SetActive (true);

						} else if (tutorialmsg == 4) {
								for (int i=0; i < 7; i++) {
										Tutorials [i].enabled = false;
								}
								for (int i=0; i < 5; i++) {
										Arrows [i].SetActive (false);
								}
								for (int i=0; i < 2; i++) {
										Sprites [i].renderer.enabled = false;
								}
								tutorialover = true;
								SaveTutorial ();
						}
				} else {
					for (int i=0; i < 7; i++) {
						Tutorials [i].enabled = false;
					}
					for (int i=0; i < 5; i++) {
						Arrows [i].SetActive (false);
					}
					for (int i=0; i < 2; i++) {
						Sprites [i].renderer.enabled = false;
					}
				}

		#if UNITY_EDITOR
		bool click = Input.GetMouseButton(0);

		if (click){
			tutorialmsg++;
		}


		//#endif
		
		#elif UNITY_ANDROID
		foreach (Touch touch in Input.touches)
		{
		if (Input.touchCount > 0){

			if (touch.phase == TouchPhase.Ended) {
			tutorialmsg++;
				}
		}
		}
		
		if (Input.GetKey (KeyCode.Escape)) {
			if (Application.loadedLevelName != "LevelSelect") {
				Application.LoadLevel("LevelSelect");
			}
			else {
				Application.Quit ();
			}
		}
		#endif
	}
	public void SaveTutorial()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file;
		file = File.Create (Application.persistentDataPath + "/Tutorial.supreme");
		TutorialDone Done = new TutorialDone();
		Done.TutorialFinish = tutorialover;
		bf.Serialize (file, Done);
		file.Close ();

	}
	public void Load()
	{

		if (File.Exists (Application.persistentDataPath + "/Tutorial.supreme")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/Tutorial.supreme", FileMode.Open);
			TutorialDone Done = (TutorialDone)bf.Deserialize (file);
			file.Close ();
			tutorialover = Done.TutorialFinish;
		}

	}
}

[Serializable]
public class TutorialDone
{
	public bool TutorialFinish;
}