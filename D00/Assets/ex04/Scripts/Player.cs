using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 0.2f;
	public string 	keyUp;
	public string 	keyDown;
	int 	move = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (keyUp)) {
			move = 1;
		}
		if (Input.GetKeyDown (keyDown)) {
			move = -1;
		}
		if (Input.GetKeyUp (keyUp) && move == 1) {
			move = 0;
		}
		if (Input.GetKeyUp (keyDown) && move == -1) {
			move = 0;
		}
		if (move == 1 && transform.localPosition.y <= 6 - speed) {
			transform.localPosition += new Vector3(0, move * speed, 0);
		} else if (move == -1 && transform.localPosition.y >= -6 + speed) {
			transform.localPosition += new Vector3(0, move * speed, 0);
		}
	}
}
