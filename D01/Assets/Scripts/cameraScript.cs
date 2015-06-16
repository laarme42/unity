using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {
	public static playerScript_ex00 controller;
	private GameObject characters;
	// Use this for initialization
	void Start () {
		//        player = GetComponent ("playerScript_ex00");
		//PlayerHandler = GameObject.Find("playerHandler");
		//controller = PlayerHandler.GetComponent<playerScript_ex00>();
		characters = GameObject.FindGameObjectWithTag("Thomas");
		//toto = GetComponent ("playerScript_ex00").gameObject;
		//Debug.Log (controller.GetController);
	}
	
	// Update is called once per frame
	void Update () {
		//PlayerHandler = GameObject.Find ("playerHandler");
		//controller = playerScript_ex00.players[playerScript_ex00.GetController];
		if (playerScript_ex00.GetController == 0) {

			if (tag == "camera1")
				characters = GameObject.FindGameObjectWithTag ("Claire");
			else if (tag == "camera2")
				characters = GameObject.FindGameObjectWithTag ("John");
			else
				characters = GameObject.FindGameObjectWithTag ("Thomas");
		}
		else if (playerScript_ex00.GetController == 1) {

			if (tag == "camera1")
				characters = GameObject.FindGameObjectWithTag ("Claire");
			else if (tag == "camera2")
				characters = GameObject.FindGameObjectWithTag ("Thomas");
			else
				characters = GameObject.FindGameObjectWithTag ("John");
		}
		else {

			if (tag == "camera1")
				characters = GameObject.FindGameObjectWithTag ("Thomas");
			else if (tag == "camera2")
				characters = GameObject.FindGameObjectWithTag ("John");
			else
				characters = GameObject.FindGameObjectWithTag ("Claire");
		}
		if (characters != null) {
			transform.position = characters.transform.position;
			transform.Translate (0, 0, -10);
		}
	}
}