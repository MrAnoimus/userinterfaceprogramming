using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	private GameObject controlledCar = null;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID
		#endif
		
		#if UNITY_EDITOR
		bool click = Input.GetMouseButton(0);
		Vector3 clickPos = Input.mousePosition;
		clickPos.z = 10;
		if (click){
			if (controlledCar == null){

				Vector3 worldPoint = Camera.main.ScreenToWorldPoint(clickPos);
				
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

		if (controlledCar != null)
		{
			float newPositionX, newPositionY = 0.0f;

			if (controlledCar.GetComponent<Car>().AllowHorizontalMovement){
				newPositionX = Camera.main.ScreenToWorldPoint(clickPos).x;
			}
			else{
				newPositionX = controlledCar.transform.position.x;
			}

			if (controlledCar.GetComponent<Car>().AllowVerticalMovement){
				newPositionY = Camera.main.ScreenToWorldPoint(clickPos).y;
			}
			else{
				newPositionY = controlledCar.transform.position.y;
			}

			controlledCar.transform.position = new Vector3(newPositionX, newPositionY);
		}
		
		#endif
	}
}






































