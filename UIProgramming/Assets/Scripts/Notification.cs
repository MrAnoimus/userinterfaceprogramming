using UnityEngine;
using System.Collections;

public class Notification : MonoBehaviour {
	public bool ShowNotification= false;
	public GameObject Game;
	float time;
	int moveleft;
	public GUIText timer;
	public GUIText moves;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time = Game.GetComponent<Game> ().time;
		moveleft = Game.GetComponent<Game> ().moves;
		if (time < 10) 
		{
			timer.guiText.material.color=Color.red;
		}
		if (moveleft < 5) 
		{
			moves.guiText.material.color=Color.red;
		}
		if( ShowNotification ==true)
			{

			}
}
}
