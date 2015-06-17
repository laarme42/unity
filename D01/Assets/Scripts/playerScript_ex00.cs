using UnityEngine;
using System.Collections;

public class playerScript_ex00 : MonoBehaviour {

	public bool 				active;
	public float				moveSpeed;
	public float				jumpingStrength;
	public GameObject[]  		players;
	public GameObject			mur;
	public GameObject			button;
	private KeyCode[]			keycodes;
	public Vector3				position;
	private static int 			controller = 0;
	private Rigidbody2D 		myRb;
	private static int 			exit = 0;
	public static int 			isPressed = 0;



	// Use this for initialization
	void Start () {
		transform.position = position;
		transform.rotation = new Quaternion(0, 0, 0, 0);
		keycodes = new KeyCode[]{KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3};
	}
	public static int GetController { get { return controller; } }
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag.Split ('_') [0] == tag) {
			exit += 1;
			if (exit == 3) {
				Debug.Log ("You win!");
				if (Application.loadedLevel != 3)
					Application.LoadLevel (Application.loadedLevel + 1);
				int index = 0;
				while (index < 3) {
					players [index].GetComponent<playerScript_ex00> ().active = false;
					players [index].GetComponent<playerScript_ex00> ().Start ();
					index += 1;
				}
				players [0].GetComponent<playerScript_ex00> ().active = true;
				exit = 0;
			}
		} else if (collider.tag.Split ('_') [0] == "teleport") {
			transform.position = new Vector3 (float.Parse (collider.tag.Split ('_') [1]), float.Parse (collider.tag.Split ('_') [2]), 0);
		} else if (collider.tag == "button" && isPressed == 0) {
			if (tag == "Thomas") {
				mur = GameObject.FindGameObjectWithTag ("mur");
				mur.GetComponent<BoxCollider2D> ().enabled = false;
				mur.GetComponent<SpriteRenderer> ().sortingOrder = -1;
				isPressed = 1;

			} else if (tag == "John") {
				mur = GameObject.FindGameObjectWithTag ("trap");
				mur.GetComponent<BoxCollider2D> ().enabled = false;
				mur.GetComponent<SpriteRenderer> ().sortingOrder = -1;
				isPressed = 2;
			}
			else
				isPressed = 3;
			button = GameObject.FindGameObjectWithTag ("button");
			button.GetComponent<Transform> ().Translate (0, -0.2F, 0);
		}
	}
	void OnTriggerExit2D(Collider2D collider)
	{
		//BOOLEEN CHECK BOUTON APPUYER
		//FOSSE POUR RECUPERER HERO CAGE PAS DE VIDE SANS FIN
		if (collider.tag == "button") {
			if (tag == "Thomas" && isPressed == 1) {
				mur = GameObject.FindGameObjectWithTag ("mur");
				mur.GetComponent<BoxCollider2D> ().enabled = true;
				mur.GetComponent<SpriteRenderer> ().sortingOrder = 1;
				button = GameObject.FindGameObjectWithTag ("button");
				button.GetComponent<Transform>().Translate(0,0.2F,0);
				isPressed = 0;

			} else if (tag == "John" && isPressed == 2) {
				mur = GameObject.FindGameObjectWithTag ("trap");
				mur.GetComponent<BoxCollider2D> ().enabled = true;
				mur.GetComponent<SpriteRenderer> ().sortingOrder = 1;
				isPressed = 0;
				button = GameObject.FindGameObjectWithTag ("button");
				button.GetComponent<Transform>().Translate(0,0.2F,0);
			}
			else if (isPressed == 3)
			{
				isPressed = 0;
				button = GameObject.FindGameObjectWithTag ("button");
				button.GetComponent<Transform>().Translate(0,0.2F,0);
			}
		}
		if (collider.tag.Split('_')[0] == tag)
			exit -= 1;
	}

	void Update () {
		myRb = players[controller].GetComponent<Rigidbody2D>();
		if (active) {

			myRb.mass = 1;
			if (Input.GetKey (KeyCode.RightArrow)) {
				myRb.velocity.Set(0, 0);
				if (myRb.velocity.x < moveSpeed * 1.5)
					myRb.AddForce(new Vector2(moveSpeed, 0), ForceMode2D.Impulse);
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				if (myRb.velocity.x > moveSpeed * -1.5)
					myRb.AddForce(new Vector2(-moveSpeed, 0), ForceMode2D.Impulse);
			}
			if (Input.GetKeyUp (KeyCode.RightArrow)) {
				myRb.velocity.Set(0, 0);
				if (myRb.velocity.x > moveSpeed * 1.5)
					myRb.AddForce(new Vector2(-moveSpeed, 0), ForceMode2D.Impulse);
			} else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
				if (myRb.velocity.x < moveSpeed * -1.5)
					myRb.AddForce(new Vector2(moveSpeed, 0), ForceMode2D.Impulse);
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				if ((myRb.velocity.y >= 0) && (myRb.velocity.y < 0.01))
					myRb.AddForce(new Vector2(0, jumpingStrength), ForceMode2D.Impulse);
			}
			int index = 0;
			while (index < 3) {
				if (players[index].GetComponent<playerScript_ex00>().active != true) {
					players[index].GetComponent<Rigidbody2D>().mass = 1000;
				}
				if (Input.GetKeyDown(keycodes[index])) {
					active = false;
					players[index].GetComponent<playerScript_ex00>().active = true;
					controller = index;
				}
				index += 1;
			}
			//camera.GetComponent<Transform>().localPosition = transform.localPosition;
			if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Backspace)) {
				index = 0;
				while (index < 3) {
					players[index].GetComponent<playerScript_ex00>().active = false;
					players[index].GetComponent<playerScript_ex00>().Start ();
					index += 1;
				}
				players[0].GetComponent<playerScript_ex00>().active = true;
				exit = 0;
				//camera.GetComponent<cameraScript>().Start();
				myRb.mass = 1000;
			}
		}
	}
}
