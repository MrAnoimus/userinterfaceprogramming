using UnityEngine;
using System.Collections;

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

	}
	
	// Update is called once per frame
	void Update () {
		timeleft = Game.GetComponent<Game>().time;
		movesleft = Game.GetComponent<Game> ().moves;
		StarPos = Stars[0].transform.position;
		level = PlayerPrefs.GetInt ("level");
		ResultedTime.guiText.pixelOffset.Set(ResultedTime.guiText.pixelOffset.x+100,0);
		if (EndOfLevel==true) 
		{
			Calculations();

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
					score=1;
					Debug.Log ("Time Score: "+score);
				}
				if(movesleft>0)
				{
					score=2;
					Debug.Log ("Move Score: "+score);
				}
				if(hintsused<0)
				{
					score=3;
					Debug.Log ("Hint Score: "+score);
				}
				if(score>3)
				{
					score=3;
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
			for (int i=0; i<3; i++) 
			{
				Stars [i].SetActive(true);
			}
			Background.guiTexture.enabled=true;
			resultsheader.guiText.enabled=true;


		} 

		if (score == 2) 
		{
			Stars[1].transform.position.Set(StarPos.x+6,StarPos.y,0);

		}
		if (score == 3) 
		{
			Stars[1].transform.position.Set(StarPos.x+2,StarPos.y,0);
			Stars[2].transform.position.Set(StarPos.x+5,StarPos.y,0);
		}
	}
}

