using UnityEngine;
using System.Collections;

public class Club : MonoBehaviour {
	
	static public int Score = -15;
	static public int Force = 0;
	static public bool keyPressed = false;
	static public bool BallBouncing = false;
	static public float Defautclub = -0.5F;
	public GameObject BallsImage;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		if (Ball.end == true)
			GameObject.Destroy(gameObject);
		// Suivre la ball une fois qu elle ne rebondit plus
		if (BallBouncing == true && Ball.Speed == 0 && BallsImage != null) {
			if (transform.position.y != (BallsImage.transform.position.y - 0.2)) {
				transform.position = new Vector3(-1, (BallsImage.transform.position.y - 0.2F), 0);
				Defautclub = BallsImage.transform.position.y - 0.2F;
				BallBouncing = false;
			}
		}
		// Presse la touche
		if (Input.GetKeyDown (KeyCode.Space)) {
			//Debug.Log ("The score is: " + Score+ " " + Force);
			keyPressed = true;
			// Descends le club
			if (transform.position.y > -4)
				transform.Translate(0F, -0.02F, 0F);
			
		}
		// Retire la touche
		else if (Input.GetKeyUp (KeyCode.Space)) {
			keyPressed = false;
			//Debug.Log ("The score is: " + Score+ " " + Force);
			//Force = 0;
			// Relache la frappe
			if (transform.position.y < Defautclub) {
				while (transform.position.y < Defautclub)
					transform.Translate(0F, +0.02F, 0F);
				Score += 5;
				Debug.Log ("score: " + Score);
				BallBouncing = true;
			}
		}
		// Maintiens la touche
		if (keyPressed == true) {

			// Descends le club
			if (transform.position.y > -2.15)
			{
				transform.Translate(0F, -0.02F, 0F);
				Force += 1;
			}
		}
	}
}
