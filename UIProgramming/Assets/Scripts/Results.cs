using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Results : MonoBehaviour {

	public int level;
	public float timeleft;
	public int movesleft;
	public int hintsused;
	int score;
	bool Calculated=false;
	public bool EndOfLevel;
	public GameObject Game;
	public GUITexture Background;
	public GameObject[] Stars;
	public GameObject[] BlackStars;
	Vector2 StarPos; 
	public GUIText resultsheader;
	public GUIText ResultedTime;
	public GUIText ResultedMoves;
	public GUIText FinalTime;
	public GUIText FinalMoves;
	// Use this for initialization
	void Start () {
		level = PlayerPrefs.GetInt ("level");
		//Exit.GetComponent<Trigger> ().isTriggered
		for (int i=0; i<3; i++) 
		{
			Stars [i].SetActive(false);
		}
		for (int i=0; i<3; i++) 
		{
			BlackStars [i].SetActive(false);
		}
		Background.guiTexture.enabled=false;
		resultsheader.guiText.enabled = false;
		FinalTime.guiText.enabled = false;
		FinalMoves.guiText.enabled = false;
		//Load ();
	}
	
	// Update is called once per frame
	void Update () {
		timeleft = Game.GetComponent<Game>().time;
		movesleft = Game.GetComponent<Game> ().moves;
		StarPos = Stars[0].transform.position;

		Render ();
		if (EndOfLevel==true) 
		{
			Calculations();
			SaveFile();
		}
		#if UNITY_EDITOR

		//#endif
		
		#elif UNITY_ANDROID

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
	void OnDestroy()
	{
		PlayerPrefs.DeleteAll();
	}
	void Calculations()
	{
		if (Calculated == false) 
		{
			score++;


				if (timeleft > 0.0f) 
				{
					score++;
					Debug.Log ("Time Score: "+score);
				}
				if(movesleft>0)
				{
					score++;
					Debug.Log ("Move Score: "+score);
				}
				if(hintsused<0)
				{
					score++;
					Debug.Log ("Hint Score: "+score);
				}
				if(score>3)
				{
					Debug.Log ("Score: "+score);
				}

			Calculated=true;

		}
	}
	void Render()
	{
		if (EndOfLevel == true) 
		{
			FinalTime.guiText.enabled = true;
			FinalMoves.guiText.enabled = true;
			FinalTime.text = "Your Time: "+ timeleft;
			FinalMoves.text = "Your Moves: "+ movesleft;
			Background.guiTexture.enabled=true;
			resultsheader.guiText.enabled=true;
			if (score == 1)
			{
				Stars[0].SetActive(true);
				BlackStars[1].SetActive(true);
				BlackStars[2].SetActive(true);
				
			}
			
			if (score == 2) 
			{
				Stars[0].SetActive(true);
				Stars[1].SetActive(true);
				BlackStars[2].SetActive(true);
				
			}
			if (score == 3) 
			{
				Stars[0].SetActive(true);
				Stars[1].SetActive(true);
				Stars[2].SetActive(true);
			}
			if(score>3)
			{
				score = 3;
			}

		} 

	}
	public void SaveFile()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file;
		if (level == 1)
		{
			file = File.Create (Application.persistentDataPath + "/Level1Score.supreme");
			LevelHighscores LocalHighScore = new LevelHighscores();
			LocalHighScore.thescore = score;
			bf.Serialize (file, LocalHighScore);
			file.Close ();
		}
		if (level == 2)
		{
			file = File.Create (Application.persistentDataPath + "/Level2Score.supreme");
			LevelHighscores LocalHighScore = new LevelHighscores();
			LocalHighScore.thescore = score;
			bf.Serialize (file, LocalHighScore);
			file.Close ();
		}
		if (level == 3)
		{
			file = File.Create (Application.persistentDataPath + "/Level3Score.supreme");
			LevelHighscores LocalHighScore = new LevelHighscores();
			LocalHighScore.thescore = score;
			bf.Serialize (file, LocalHighScore);
			file.Close ();
		}

	}
}




	
