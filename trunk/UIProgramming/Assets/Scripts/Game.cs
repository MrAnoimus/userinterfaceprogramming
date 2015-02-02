using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	private GameObject controlledCar = null;

	public float carSpeed = 10.0f;

	public AudioClip[] AudioClips; 

	public Vector2[] CarSpawn_H, CarSpawn_V;
	public GameObject Car_H, Car_V;

	public GameObject Exit;

	public int level;
	public float time = 30.0f;
	public int moves;
	
	public GUIText gui_textLevel;
	public GUIText gui_textTime;
	public GUIText gui_textMoves;

	// Use this for initialization
	void Start () {
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
		time = 30.0f;
		moves = 0;
		
		gui_textLevel.text = "Level " + level;
		gui_textTime.text = "Timer: " + time.ToString("F2") + " s";
		gui_textMoves.text = "Moves: " + moves;
	}
	public void PlaySound(int selection)
	{
			audio.clip = AudioClips [selection];
			audio.Play ();
	}
	// Update is called once per frame
	void Update () {

		time -= Time.deltaTime;
		
		gui_textLevel.text = "Level " + level;
		gui_textTime.text = "Timer: " + time.ToString("F2") + " s";
		gui_textMoves.text = "Moves: " + moves;

		if (Exit.GetComponent<Trigger> ().isTriggered) {
			Application.LoadLevel("MainMenu");
		}

		Vector3 inputPos = new Vector2(0,0);


		#if UNITY_EDITOR
		bool click = Input.GetMouseButton(0);
		inputPos = Input.mousePosition;
		inputPos.z = 10;
		if (click){
			Debug.Log ("Clicked: " + inputPos);
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
		else if (controlledCar != null){
			moves++;
			controlledCar = null;
		}		
		//#endif

		#elif UNITY_ANDROID
		if (Input.touchCount > 0){
			inputPos = Input.GetTouch(0).position;
			inputPos.z = 10;
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
		else{
			controlledCar = null;
		}
		#endif
		if (controlledCar != null)
		{
			PlaySound(0);
			Vector2 inputWorldPos = Camera.main.ScreenToWorldPoint(inputPos);
			Vector2 currentPos = controlledCar.transform.position;

			if (controlledCar.GetComponent<Car>().AllowHorizontalMovement){
				if (inputWorldPos.x - currentPos.x < -carSpeed * Time.deltaTime){
					if (!controlledCar.GetComponent<Car>().FrontTrigger.GetComponent<Trigger>().isTriggered){
						currentPos += new Vector2(-carSpeed * Time.deltaTime, 0);
					}
				}
				else if (inputWorldPos.x - currentPos.x > carSpeed * Time.deltaTime){
					if (!controlledCar.GetComponent<Car>().BackTrigger.GetComponent<Trigger>().isTriggered){
						currentPos += new Vector2(carSpeed * Time.deltaTime, 0);
					}
				}
			}

			
			if (controlledCar.GetComponent<Car>().AllowVerticalMovement){
				if (inputWorldPos.y - currentPos.y < -carSpeed * Time.deltaTime){
					if (!controlledCar.GetComponent<Car>().BackTrigger.GetComponent<Trigger>().isTriggered){
						currentPos += new Vector2(0, -carSpeed * Time.deltaTime);
					}
				}
				else if (inputWorldPos.y - currentPos.y > carSpeed * Time.deltaTime){
					if (!controlledCar.GetComponent<Car>().FrontTrigger.GetComponent<Trigger>().isTriggered){
						currentPos += new Vector2(0, carSpeed * Time.deltaTime);
					}
				}
			}
			controlledCar.transform.position = currentPos;
		}
	}
}






































