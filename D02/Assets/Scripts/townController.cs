using UnityEngine;
using System.Collections;

public class townController : MonoBehaviour {

	public int			life;
	private float 		time;
	private float 		spawnTime;
	public GameObject	race;

	// Use this for initialization
	void Start () {
		life = 100;
		time = 0;
		spawnTime = 10;
		if (race.tag == "player") {
			townController2.HumanDestroy += BuildingDestroyEvent;
		} else {
			townController2.OrcDestroy += BuildingDestroyEvent;
		}
		GameObject.Instantiate(race, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= spawnTime) {
			time = 0;
			GameObject.Instantiate(race, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
		}
		if (life <= 0) {
			GameObject.Destroy(gameObject);
			Debug.Log("Game Over");
		}
	}

	void BuildingDestroyEvent() {
		spawnTime += 2.5f;
		Debug.Log ("BuildingDestroyEvent");
	}
}
