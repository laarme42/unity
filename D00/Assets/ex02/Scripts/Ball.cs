using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	static public int Speed = 0;
	static public bool Dir = true;
	static public bool end = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Club.Force > 0 && Input.GetKeyUp (KeyCode.Space)) {
			//Debug.Log ("The score is: " + Club.Score + " " + Club.Force);
			Speed = Club.Force;
			Dir = true;
			Club.Force = 0;
			//Debug.Log ("The pos is: " + transform.position.y + " " + Speed);
		}
		if (Speed > 0) {
			if (transform.position.y >= 11) {
				Dir = false;
			}
			else if (transform.position.y <= -2) {
				Dir = true;
			}
			if (Dir == true) {
				transform.Translate(0, 0.4F, 0);
				Speed -= 1;
			}
			else {
				transform.Translate(0, -0.4F, 0);
				Speed -= 1;
			}
		}
		if (Speed < 5 && Speed >= 0) {
			if (transform.position.y > 9 && transform.position.y < 10) {
				GameObject.Destroy(gameObject);
				end = true;
				if (Club.Score <= 0)
					Debug.Log ("CONGRATULATION !!!, YOUR SCORE IS " + Club.Score);
				else
					Debug.Log ("GAME OVER !!! SORRY, YOUR SCORE IS " + Club.Score);

			}
		}
	}
}
