using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	private GameObject controlledCar = null;

	public float carSpeed = 10.0f;

	public AudioClip[] AudioClips; 
	// Use this for initialization
	void Start () {
	
	}
	public void PlaySound(int selection)
	{
			audio.clip = AudioClips [selection];
			audio.Play ();
	}
	// Update is called once per frame
	void Update () {
		Vector3 inputPos;

		#if UNITY_ANDROID
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
		
		#if UNITY_EDITOR
		bool click = Input.GetMouseButton(0);
		inputPos = Input.mousePosition;
		inputPos.z = 10;
		if (click){
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
			if (controlledCar.GetComponent<Car>().AllowVerticalMovement){
				//newPositionY = Camera.main.ScreenToWorldPoint(inputPos).y;
			}
			
			controlledCar.transform.position = currentPos;
		}
	}
}






































