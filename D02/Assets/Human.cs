using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Human : MonoBehaviour {
	
	public List<GameObject> players = new List<GameObject>();
	public Vector3 			target;
	public bool 			going;
	public GameObject 		fire;
	public bool 			isFire;
	private float			time;
	public int				life;
	public Vector3			position;
	public int 				dirX;
	public int 				dirY;
	
	// Use this for initialization
	void Start () {
		life = 50;
		time = 0;
		going = false;
		isFire = false;
		transform.position = position;
	}

	void setAnimation(int DirX, int DirY) {
		if (DirX == 1 && DirY == 1) {
				
				if (target.y - transform.position.y < 0.4)
					GetComponent<Animator> ().SetBool ("runR", true);
				else if (target.x - transform.position.x < 0.4)
					GetComponent<Animator> ().SetBool ("runT", true);
				else
					GetComponent<Animator> ().SetBool ("runDiagTR", true);
				
				
			} else if (DirX == -1 && DirY == -1) {
				if (target.y - transform.position.y > -0.4)
					GetComponent<Animator> ().SetBool ("runL", true);
				else if (target.x - transform.position.x > -0.4)
					GetComponent<Animator> ().SetBool ("runB", true);
				else
					GetComponent<Animator> ().SetBool ("runDiagBL", true);
			} else if (DirX == -1 && DirY == 1) {
				if (target.y - transform.position.y > -0.4)
					GetComponent<Animator> ().SetBool ("runL", true);
				else if (target.x - transform.position.x < 0.4)
					GetComponent<Animator> ().SetBool ("runT", true);
				else
					GetComponent<Animator> ().SetBool ("runDiagTL", true);
			} else if (DirX == 1 && DirY == -1) {
				if (target.y - transform.position.y < 0.4)
					GetComponent<Animator> ().SetBool ("runR", true);
				else if (target.x - transform.position.x > -0.4)
					GetComponent<Animator> ().SetBool ("runB", true);
				else
					GetComponent<Animator> ().SetBool ("runDiagBR", true);
			} else if (DirX == 1 && DirY == 0) {
				GetComponent<Animator> ().SetBool ("runR", true);
			} else if (DirX == -1 && DirY == 0) {
				GetComponent<Animator> ().SetBool ("runL", true);
			} else if (DirX == 0 && DirY == 1) {
				GetComponent<Animator> ().SetBool ("runT", true);
			} else if (DirX == 0 && DirY == -1) {
				GetComponent<Animator> ().SetBool ("runB", true);
			}
	}

	// Update is called once per frame
	void Update () {

		if (life <= 0) {
			GameObject.Destroy(gameObject);
		}

		time += Time.deltaTime;
		if (time >= 2) {
			time = 0;
			if (fire) {
				if (isFire) {
					if (fire.GetComponent<townController>())
						fire.GetComponent<townController>().life -= 5;
					else if (fire.GetComponent<townController2>())
						fire.GetComponent<townController2>().life -= 5;
					else if (fire.GetComponent<Human>())
						fire.GetComponent<Human>().life -= 5;
				}
			} else {
				isFire = false;
			}
		}
	
		if (going) {

			dirX = 0;
			dirY = 0;
			if ((Vector3.Distance (target, transform.position)) > 0.5) {
				dirX = 0;
				dirY = 0;
				if (target.x - transform.position.x > 0.2) {
					dirX = 1;
				} else if (target.x - transform.position.x < -0.2) {
					dirX = -1;
				}
				if (target.y - transform.position.y > 0.2) {
					dirY = 1;
				} else if (target.y - transform.position.y < -0.2) {
					dirY = -1;
				}
			}
			
			setAnimation (dirX, dirY);

			if (target.y > transform.position.y - 0.2 && target.y < transform.position.y + 0.2 && target.x > transform.position.x - 0.2 && target.x < transform.position.x + 0.2) {
				going = false;
				SoundManager.instance.Stop ();
				GetComponent<Animator> ().SetBool ("runDiagTR", false);
				GetComponent<Animator> ().SetBool ("runDiagTL", false);
				GetComponent<Animator> ().SetBool ("runDiagBR", false);
				GetComponent<Animator> ().SetBool ("runDiagBL", false);
				GetComponent<Animator> ().SetBool ("runT", false);
				GetComponent<Animator> ().SetBool ("runB", false);
				GetComponent<Animator> ().SetBool ("runR", false);
				GetComponent<Animator> ().SetBool ("runL", false);

			} else
				transform.Translate ((float)(dirX * 0.1F), (float)(dirY * 0.1F), Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject == fire) {
			isFire = true;
			going = false;
			SoundManager.instance.Stop ();
			GetComponent<Animator> ().SetBool ("runDiagTR", false);
			GetComponent<Animator> ().SetBool ("runDiagTL", false);
			GetComponent<Animator> ().SetBool ("runDiagBR", false);
			GetComponent<Animator> ().SetBool ("runDiagBL", false);
			GetComponent<Animator> ().SetBool ("runT", false);
			GetComponent<Animator> ().SetBool ("runB", false);
			GetComponent<Animator> ().SetBool ("runR", false);
			GetComponent<Animator> ().SetBool ("runL", false);
			
			GetComponent<Animator> ().SetBool ("attackB", true);
		}
	}
	
	void OnTriggerExit2D(Collider2D collider) {
		if (collider.gameObject == fire) {
			isFire = false;
			fire = new GameObject();
			GetComponent<Animator> ().SetBool ("attackB", false);
		}
	}
}