using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	private GameObject controlledCar = null;
	

	// Use this for initialization
	void Start () {
	
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
			float newPositionX, newPositionY = 0.0f;
			
			if (controlledCar.GetComponent<Car>().AllowHorizontalMovement){
				newPositionX = Camera.main.ScreenToWorldPoint(inputPos).x;
			}
			else{
				newPositionX = controlledCar.transform.position.x;
			}
			
			if (controlledCar.GetComponent<Car>().AllowVerticalMovement){
				newPositionY = Camera.main.ScreenToWorldPoint(inputPos).y;
			}
			else{
				newPositionY = controlledCar.transform.position.y;
			}
			
			controlledCar.transform.position = new Vector3(newPositionX, newPositionY);
		}
	}
}






































