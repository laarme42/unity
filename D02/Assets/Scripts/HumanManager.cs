using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanManager : MonoBehaviour {
	
	public List<GameObject> players = new List<GameObject>();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector3.zero);
			if (hit && hit.collider) {
				if (hit.collider.tag == "player" && !Input.GetKey (KeyCode.LeftControl)) {
					foreach (GameObject player in players) {
						player.GetComponent<SpriteRenderer>().color = new Color(1,1,1);
						player.GetComponent<Animator> ().SetBool ("runDiagTR", false);
						player.GetComponent<Animator> ().SetBool ("runDiagTL", false);
						player.GetComponent<Animator> ().SetBool ("runDiagBR", false);
						player.GetComponent<Animator> ().SetBool ("runDiagBL", false);
						player.GetComponent<Animator> ().SetBool ("runT", false);
						player.GetComponent<Animator> ().SetBool ("runB", false);
						player.GetComponent<Animator> ().SetBool ("runR", false);
						player.GetComponent<Animator> ().SetBool ("runL", false);
						player.GetComponent<Human> ().going = false;
					}
					players = new List<GameObject> ();
					players.Add (hit.collider.gameObject);
					hit.collider.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,0.4F);
				} else if (hit.collider.tag == "player" && !players.Contains (hit.collider.gameObject) && Input.GetKey (KeyCode.LeftControl)) {
					foreach (GameObject player in players) {
						player.GetComponent<Human> ().going = false;
					}
					players.Add (hit.collider.gameObject);
					hit.collider.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,0.4F);
				} else if (hit.collider.tag == "orc_town" || hit.collider.tag == "orc") {
					/*foreach (GameObject player in players) {
						if (hit.collider.gameObject.transform.position.y >= player.transform.position.y - 2 && hit.collider.gameObject.transform.position.y <= player.transform.position.y + 2
						    && hit.collider.gameObject.transform.position.x >= player.transform.position.x - 2 && hit.collider.gameObject.transform.position.x <= player.transform.position.x + 2) {
							if (hit.collider.GetComponent<townController>())
								hit.collider.GetComponent<townController>().life -= 5;
							else
								hit.collider.GetComponent<townController2>().life -= 5;
						} else {
							target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
							going = true;
							SoundManager.instance.Play ();
						}
					}*/
					foreach (GameObject player in players) {
						if (player.GetComponent<Human>().fire != hit.collider.gameObject) {
							player.GetComponent<Human>().fire = hit.collider.gameObject;
							player.GetComponent<Human>().target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
							player.GetComponent<Human>().going = true;
						}
					}
						SoundManager.instance.Play ();
				}
			} else if (players [0] != null) {
				foreach (GameObject player in players) {
					player.GetComponent<Human>().target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					player.GetComponent<Human>().going = true;
					player.GetComponent<Human>().fire = new GameObject();
					player.GetComponent<Animator> ().SetBool ("attackB", false);

				}
				SoundManager.instance.Play ();
			}
				
		} else if (Input.GetMouseButtonDown (1)) {
			foreach (GameObject player in players) {
				player.GetComponent<SpriteRenderer>().color = new Color(1,1,1);
				player.GetComponent<Human>().going = false;
				player.GetComponent<Animator> ().SetBool ("runDiagTR", false);
				player.GetComponent<Animator> ().SetBool ("runDiagTL", false);
				player.GetComponent<Animator> ().SetBool ("runDiagBR", false);
				player.GetComponent<Animator> ().SetBool ("runDiagBL", false);
				player.GetComponent<Animator> ().SetBool ("runT", false);
				player.GetComponent<Animator> ().SetBool ("runB", false);
				player.GetComponent<Animator> ().SetBool ("runR", false);
				player.GetComponent<Animator> ().SetBool ("runL", false);
			}
			players = new List<GameObject> ();
		}
	}
}