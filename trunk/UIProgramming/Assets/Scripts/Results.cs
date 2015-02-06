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
	Vector2 StarPos; 
	public GUIText resultsheader;
	public GUIText ResultedTime;
	public GUIText ResultedMoves;
	// Use this for initialization
	void Start () {

		//Exit.GetComponent<Trigger> ().isTriggered
		for (int i=0; i<3; i++) 
		{
			Stars [i].SetActive(false);
		}
		Background.guiTexture.enabled=false;
		resultsheader.guiText.enabled = false;
		Load ();
	}
	
	// Update is called once per frame
	void Update () {
		timeleft = Game.GetComponent<Game>().time;
		movesleft = Game.GetComponent<Game> ().moves;
		StarPos = Stars[0].transform.position;
		level = PlayerPrefs.GetInt ("level");

		if (EndOfLevel==true) 
		{
			Calculations();
			SaveFile();
		}
		Render ();

	}

	void Calculations()
	{
		if (Calculated == false) 
		{
			score++;
			level = PlayerPrefs.GetInt ("level");
			if (level == 2) 
			{
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
			}
			Calculated=true;

		}
	}
	void Render()
	{
		if (EndOfLevel == true) 
		{

			Background.guiTexture.enabled=true;
			resultsheader.guiText.enabled=true;
			if (score == 1)
			{
				Stars[0].SetActive(true);
				
			}
			
			if (score == 2) 
			{
				Stars[0].SetActive(true);
				Stars[1].SetActive(true);
				
			}
			if (score == 3) 
			{
				Stars[0].SetActive(true);
				Stars[1].SetActive(true);
				Stars[2].SetActive(true);
			}
			if(score>3)
			{
				resultsheader.guiText.text="SUPREME";
			}

		} 

	}
	public void SaveFile()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/HighScores.supreme");
		
		HighScore LocalHighScore = new HighScore();
		LocalHighScore.scores = score;
		
		bf.Serialize (file, LocalHighScore);
		file.Close ();
	}
	
	public void Load()
	{
		if(File.Exists(Application.persistentDataPath+ "/HighScores.supreme"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath+ "/HighScores.supreme", FileMode.Open);
			HighScore LocalHighscore = (HighScore)bf.Deserialize(file);
			file.Close();
			score = LocalHighscore.scores+10;
		}
	}
}

[Serializable]
class HighScore
{
	public int scores;
}

	
