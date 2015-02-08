using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class Game : MonoBehaviour {

	private GameObject controlledCar = null;
	public GameObject Tutorials;
	public float carSpeed = 10.0f;

	public AudioClip[] AudioClips; 

	public GameObject Car_H, Car_V;

	public GameObject Exit;

	public int level;
	public float time = 2.0f;
	public int moves;
	
	public GUIText gui_textLevel;
	public GUIText gui_textTime;
	public GUIText gui_textMoves;

	public GUITexture gui_buttonRestart;
	public GUITexture gui_buttonHints;
	public GUITexture gui_buttonPause;

	public bool Pause = false;
	//bool PracticeMode = false;

	public GameObject GameClear;

	bool tutorialOver;
	// Use this for initialization
	void Start () {
		tutorialOver = Tutorials.GetComponent<Tutorial> ().tutorialover;

		/*//spawn cars here
		for (int i = 0; i < CarSpawn_H.Length; ++i) {
			Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector3(CarSpawn_H[i].x, CarSpawn_H[i].y, 10));
			pos.x *= Screen.width / 221;
			pos.y *= Screen.height / 354;
			Vector3 pos1 = new Vector3(pos.x, pos.y, 0);
			Instantiate(Car_H, pos1, Car_H.transform.rotation);
		}
		
		for (int i = 0; i < CarSpawn_V.Length; ++i) {
			Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector3(CarSpawn_V[i].x, CarSpawn_V[i].y, 10));
			pos.x *= Screen.width / 221;
			pos.y *= Screen.height / 354;
			Vector3 pos1 = new Vector3(pos.x, pos.y, 0);
			Instantiate(Car_V, pos1, Car_V.transform.rotation);			
		}
		*/

		level = PlayerPrefs.GetInt ("level");
		time = 2.0f;
		moves = 5;
		
		gui_textLevel.text = "Level " + level;
		gui_textTime.text = "Timer: " + time.ToString("F2") + " s";
		gui_textMoves.text = "Moves: " + moves;

		ChangeLevel (level);
	}

	public void ChangeLevel(int targetLevel){
		Debug.Log ("Level" + targetLevel);

		GameObject Levels = GameObject.Find ("Levels").gameObject;
		GameObject LevelX = Levels.transform.Find ("Level" + targetLevel).gameObject;

		if (LevelX != null) {

			GameObject currentLevel = Instantiate(LevelX, LevelX.transform.position, Quaternion.identity) as GameObject;

			currentLevel.SetActive(true);
			currentLevel.name = "CurrentLevel";
			Debug.Log ("Level instantiated");
		}
		
	}

	public void PlaySound(int selection)
	{
			audio.clip = AudioClips [selection];
			audio.Play ();
	}

	// Update is called once per frame
	void Update () {
		if (Tutorials.GetComponent<Tutorial> ().tutorialover==true) {
						if (GameClear.GetComponent<Results> ().EndOfLevel == false) {
								if (level == 0) {
										gui_textLevel.text = "Practice";
										gui_textTime.text = "Timer: " + " Practice";
										gui_textMoves.text = "Moves: " + " Practice";
								} else {
										time -= Time.deltaTime;
										gui_textLevel.text = "Level " + level;
										if (!Pause) {
											gui_textTime.text = "Timer: " + time.ToString ("F2") + " s";
										}
										gui_textMoves.text = "Moves: " + moves;

					}

			} else {
					gui_textLevel.enabled = false;
					//gui_textTime.enabled=false;
					//gui_textMoves.enabled=false;
			}
			if (Exit.GetComponent<Trigger> ().isTriggered) {
					if (level > 0) {
							Debug.Log ("Level:" + level);
							Debug.Log ("Game Clear:" + GameClear.GetComponent<Results> ().EndOfLevel);
							//Application.LoadLevel("MainMenu");
							GameClear.GetComponent<Results> ().EndOfLevel = true;
							gui_textTime.enabled = false;
							gui_textMoves.enabled = false;
							Car_H.SetActive (false);
							Car_V.SetActive (false);
							controlledCar = null;
					}

			}

			Vector3 inputPos = new Vector2 (0, 0);


			#if UNITY_EDITOR
			bool click = Input.GetMouseButton (0);
			inputPos = Input.mousePosition;
			inputPos.z = 10;
			if (click) {
					if (GameClear.GetComponent<Results> ().EndOfLevel == false) {
							if (gui_buttonPause.HitTest (inputPos)) {
									Pause = !Pause;
							}
					}
					if (Pause == false) {
							if (gui_buttonHints.HitTest (inputPos)) {
							} else if (gui_buttonRestart.HitTest (inputPos)) {
							}
							//Debug.Log ("Clicked: " + inputPos);
							if (controlledCar == null) {
		
									Vector3 worldPoint = Camera.main.ScreenToWorldPoint (inputPos);
		
									RaycastHit2D hit = Physics2D.Raycast (new Vector2 (worldPoint.x, worldPoint.y), Vector2.zero);
		
									if (hit != null) {
											if (hit.collider.gameObject.tag == "Car") {
													//PlaySound(0);
													controlledCar = hit.collider.gameObject;
											}
									}
							}
					}
			} else if (controlledCar != null) {
					if (GameClear.GetComponent<Results> ().EndOfLevel == false) {
							if (level != 0) {
									moves--;
		
							}
							controlledCar = null;

					}	

			}	

			//#endif

						#elif UNITY_ANDROID
		if (Input.touchCount > 0){
			inputPos = Input.GetTouch(0).position;
			inputPos.z = 10;
			if(GameClear.GetComponent<Results>().EndOfLevel==false)
			{
			if (gui_buttonPause.HitTest(inputPos))
			{
				if (Input.GetTouch (0).phase == TouchPhase.Ended) {
					Pause = !Pause;
				}
			}
			}
			if (Pause == false)
			{
				if (gui_buttonHints.HitTest (inputPos)) {
				}
				else if (gui_buttonRestart.HitTest (inputPos)) {
				}
				if (controlledCar == null){
					
					Vector3 worldPoint = Camera.main.ScreenToWorldPoint(inputPos);
					
					RaycastHit2D hit = Physics2D.Raycast (new Vector2(worldPoint.x, worldPoint.y), Vector2.zero);
					
					if (hit != null)
					{
						
						if (hit.collider.gameObject.tag == "Car")
						{
							//PlaySound(0);
							controlledCar = hit.collider.gameObject;
						}
					}
				}
			}
		}
		else if (controlledCar != null){
			moves--;
			controlledCar = null;
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
						if (controlledCar != null) {
								PlaySound (0);
								Vector2 inputWorldPos = Camera.main.ScreenToWorldPoint (inputPos);
								Vector2 currentPos = controlledCar.transform.position;

								if (controlledCar.GetComponent<Car> ().AllowHorizontalMovement) {
										if (inputWorldPos.x - currentPos.x < -carSpeed * Time.deltaTime) {
												if (!controlledCar.GetComponent<Car> ().FrontTrigger.GetComponent<Trigger> ().isTriggered) {
														currentPos += new Vector2 (-carSpeed * Time.deltaTime, 0);
												}
										} else if (inputWorldPos.x - currentPos.x > carSpeed * Time.deltaTime) {
												if (!controlledCar.GetComponent<Car> ().BackTrigger.GetComponent<Trigger> ().isTriggered) {
														currentPos += new Vector2 (carSpeed * Time.deltaTime, 0);
												}
										}
								}

			
								if (controlledCar.GetComponent<Car> ().AllowVerticalMovement) {
										if (inputWorldPos.y - currentPos.y < -carSpeed * Time.deltaTime) {
												if (!controlledCar.GetComponent<Car> ().BackTrigger.GetComponent<Trigger> ().isTriggered) {
														currentPos += new Vector2 (0, -carSpeed * Time.deltaTime);
												}
										} else if (inputWorldPos.y - currentPos.y > carSpeed * Time.deltaTime) {
												if (!controlledCar.GetComponent<Car> ().FrontTrigger.GetComponent<Trigger> ().isTriggered) {
														currentPos += new Vector2 (0, carSpeed * Time.deltaTime);
												}
										}
								}
								controlledCar.transform.position = currentPos;
						}
				}

		}
}
