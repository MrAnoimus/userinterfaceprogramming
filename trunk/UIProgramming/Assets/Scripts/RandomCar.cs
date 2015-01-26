using UnityEngine;
using System.Collections;

public class RandomCar : MonoBehaviour {

	public GameObject Chassis;

	public bool LMAO = false;

	// Use this for initialization
	void Start () {
		Chassis.GetComponent<SpriteRenderer> ().color = new Color(Random.Range(0.0f,1.0f), Random.Range(0.0f,1.0f), Random.Range(0.0f,1.0f));
	}
	
	// Update is called once per frame
	void Update () {
		if (LMAO) {
			Chassis.GetComponent<SpriteRenderer> ().color = new Color (Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f));	
		}
	}
}
