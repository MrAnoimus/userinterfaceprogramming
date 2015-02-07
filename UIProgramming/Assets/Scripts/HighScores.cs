using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class HighScores : MonoBehaviour{

	public GameObject[] Stars;
	public GameObject[] BlackStars;
	public int scores;
	int score;
	public int levels;
	public GameObject LevelSelection;
	LevelHighscores Level1Score = new LevelHighscores();
	LevelHighscores Level2Score = new LevelHighscores();
	LevelHighscores Level3Score = new LevelHighscores();
	// Use this for initialization
	void Start () {
		levels = PlayerPrefs.GetInt("level");
		Level1Score.thescore = 0;
		Level2Score.thescore = 0; 
		Level3Score.thescore = 0; 
		Stars[0].SetActive(false);
		Stars[1].SetActive(false);
		Stars[2].SetActive(false);
		BlackStars[0].SetActive(false);
		BlackStars[1].SetActive(false);
		BlackStars[2].SetActive(false);
		Load ();
	}
	
	// Update is called once per frame
	void Update () {

		Load ();
		Render ();
		levels = PlayerPrefs.GetInt("level");


	}
	public void Load()
	{
		if (levels == 1) 
		{
			if (File.Exists (Application.persistentDataPath + "/Level1Score.supreme")) {
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Open (Application.persistentDataPath + "/Level1Score.supreme", FileMode.Open);
				LevelHighscores LocalHighscore = (LevelHighscores)bf.Deserialize (file);
				file.Close ();
				Level1Score.thescore = LocalHighscore.thescore;
				Debug.Log("Score: "+ Level1Score.thescore);
			}
		}
		else if (levels == 2) 
		{
			if (File.Exists (Application.persistentDataPath + "/Level2Score.supreme")) {
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Open (Application.persistentDataPath + "/Level2Score.supreme", FileMode.Open);
				LevelHighscores LocalHighscore = (LevelHighscores)bf.Deserialize (file);
				file.Close ();
				Level2Score.thescore = LocalHighscore.thescore;
				Debug.Log("Levl 2 Score: "+ Level2Score.thescore);
			}
		}
		else if (levels == 3) 
		{
			if (File.Exists (Application.persistentDataPath + "/Level3Score.supreme")) {
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Open (Application.persistentDataPath + "/Level3Score.supreme", FileMode.Open);
				LevelHighscores LocalHighscore = (LevelHighscores)bf.Deserialize (file);
				file.Close ();
				Level3Score.thescore = LocalHighscore.thescore;
			}
		}
	}
	void Render()
	{
		if (levels == 0) 
		{
			for (int i=0; i<3; i++) 
			{
				Stars[i].SetActive(false);
				BlackStars[i].SetActive(false);
			}
		}
		else if (levels == 1) 
		{

			for (int i=0; i<3; i++) 
			{
				Stars[i].SetActive(false);
				BlackStars[i].SetActive(true);
			}
			if(Level1Score.thescore==1)
			{
				Stars[0].SetActive(true);
				BlackStars[0].SetActive(false);


			}
			else if(Level1Score.thescore==2)
			{
				Stars[0].SetActive(true);
				Stars[1].SetActive(true);
				BlackStars[0].SetActive(false);
				BlackStars[1].SetActive(false);
			

			}
			else if(Level1Score.thescore==3)
			{
				Stars[0].SetActive(true);
				Stars[1].SetActive(true);
				Stars[2].SetActive(true);
				BlackStars[0].SetActive(false);
				BlackStars[1].SetActive(false);
				BlackStars[2].SetActive(false);
			}
		}
		else if (levels == 2) 
		{
			for (int i=0; i<3; i++) 
				{
					Stars[i].SetActive(false);
					BlackStars[i].SetActive(true);
				}


			 if(Level2Score.thescore==1)
			{
				Stars[0].SetActive(true);
				BlackStars[0].SetActive(false);

				
			}
			else if(Level2Score.thescore==2)
			{
				Stars[0].SetActive(true);
				Stars[1].SetActive(true);
				BlackStars[0].SetActive(false);
				BlackStars[1].SetActive(false);

				
			}
			else if(Level2Score.thescore==3)
			{
				Stars[0].SetActive(true);
				Stars[1].SetActive(true);
				Stars[2].SetActive(true);
				BlackStars[0].SetActive(false);
				BlackStars[1].SetActive(false);
				BlackStars[2].SetActive(false);
			}
		}
		else if (levels == 3) 
		{
			for (int i=0; i<3; i++) 
			{
				Stars[i].SetActive(false);
				BlackStars[i].SetActive(true);
			}
			
			
			if(Level3Score.thescore==1)
			{
				Stars[0].SetActive(true);
				BlackStars[0].SetActive(false);

				
			}
			else if(Level3Score.thescore==2)
			{
				Stars[0].SetActive(true);
				Stars[1].SetActive(true);
				BlackStars[0].SetActive(false);
				BlackStars[1].SetActive(false);

				
			}
			else if(Level3Score.thescore==3)
			{
				Stars[0].SetActive(true);
				Stars[1].SetActive(true);
				Stars[2].SetActive(true);
				BlackStars[0].SetActive(false);
				BlackStars[1].SetActive(false);
				BlackStars[2].SetActive(false);
			}
		}

	}
}
[Serializable]
public class LevelHighscores
{
	public int thescore;
}