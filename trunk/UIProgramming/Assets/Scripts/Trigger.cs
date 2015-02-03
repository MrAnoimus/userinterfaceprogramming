using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public bool isTriggered = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isTriggered) {
			//Debug.Log("TRIGGERED");		
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		isTriggered = true;
	}
	
	void OnTriggerStay2D(Collider2D other){
		isTriggered = true;
	}
	
	void OnTriggerExit2D(Collider2D other){
		isTriggered = false;
	}
}
