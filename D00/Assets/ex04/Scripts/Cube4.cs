using UnityEngine;
using System.Collections;

public class Cube4 : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;
	public float dirX = 0.2f;
	public float dirY = 0.2f;
	private int[]	scores = new int[2]{0, 0};

	// Use this for initialization
	void Start () {
		int rand = Random.Range (-8, 8);
		transform.position = new Vector3(0, rand, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (dirX, dirY, 0);
		if (transform.localPosition.y > 8 || transform.localPosition.y < -8) {
			dirY = - dirY;
			transform.Translate (dirX, dirY, 0);
		}  
		if (transform.localPosition.x > 9 || transform.localPosition.x < -9) {
			if (transform.localPosition.x < -9)
				scores[1] += 1;
			else
				scores[0] += 1;
			int rand = Random.Range (-8, 8);
			transform.position = new Vector3 (0, rand, 0);
			Debug.Log ("Player 1: "+ scores[0] + " | Player 2: " + scores[1]);
		} else if ((transform.localPosition.x <= -8.25
			&& transform.localPosition.y > player1.transform.localPosition.y - player1.transform.localScale.y / 2
			&& transform.localPosition.y < player1.transform.localPosition.y + player1.transform.localScale.y / 2) || (transform.localPosition.x >= 8.25
		           && transform.localPosition.y > player2.transform.localPosition.y - player2.transform.localScale.y / 2
		           && transform.localPosition.y < player2.transform.localPosition.y + player2.transform.localScale.y / 2)) {
		
			dirX = - dirX;
			transform.Translate (dirX, dirY, 0);
		}
	}
}
