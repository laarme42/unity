using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OrcManager : MonoBehaviour {
	
	public List<GameObject> players = new List<GameObject>();
	public Vector3 target;
	public bool going;
	
	// Use this for initialization
	void Start () {
		going = false;
		transform.position = new Vector3(3.5f, 1.5f, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if (going) {
			foreach (GameObject player in players) {
				if ((Vector3.Distance (target, player.transform.position)) > 0.5) { 
					//player.transform.LookAt (transform.position); 
					player.GetComponent<Animator>().SetTrigger("runT");
					player.transform.Translate ((target.x - player.transform.position.x) / 10, (target.y - player.transform.position.y) / 10, Time.deltaTime);   

				}
				if (target.y >= player.transform.position.y - 0.1 && target.y <= player.transform.position.y + 0.1 && target.x >= player.transform.position.x - 0.1 && target.x <= player.transform.position.x + 0.1) {
					going = false;
					SoundManager.instance.Stop ();
					//Debug.Log("fin");
				}

			}
			
		}

		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector3.zero);
			if (hit && hit.collider) {
				if (hit.collider.tag == "player" && !Input.GetKey (KeyCode.LeftControl)) {
					players = new List<GameObject> ();
					players.Add (hit.collider.gameObject);
					hit.collider.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,0.4F);
				} else if (hit.collider.tag == "player" && !players.Contains (hit.collider.gameObject) && Input.GetKey (KeyCode.LeftControl)) {
					players.Add (hit.collider.gameObject);
					hit.collider.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,0.4F);
				} else if (hit.collider.tag == "human_town") {
					foreach (GameObject player in players) {
						if (hit.collider.gameObject.transform.position.y >= player.transform.position.y - 0.1 && hit.collider.gameObject.transform.position.y <= player.transform.position.y + 0.1
						    && hit.collider.gameObject.transform.position.x >= player.transform.position.x - 0.1 && hit.collider.gameObject.transform.position.x <= player.transform.position.x + 0.1) {
							if (hit.collider.GetComponent<townController>())
								hit.collider.GetComponent<townController>().life -= 5;
							else
								hit.collider.GetComponent<townController2>().life -= 5;
						}
					}
				}
			} else if (players [0] != null) {       // the button is pressed
				target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				going = true;
				SoundManager.instance.Play ();
			}
				
		} else if (Input.GetMouseButtonDown (1)) {
			going = false;
			foreach (GameObject player in players) {
				player.GetComponent<SpriteRenderer>().color = new Color(1,1,1);
			}
			players = new List<GameObject> ();
		}
		
	}
}