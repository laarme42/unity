using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour {

	public int spawnTime;
	public static float timer = 0;
	public GameObject[] prefabs;
	public GameObject[] objects;
	private string[] keycodes = new string[]{"a", "s", "d"};
	private bool[] hasCube = new bool[]{false, false, false};
	private float[] poss = new float[]{-2.1f, 0, 2.1f};
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if (timer >= spawnTime) {
			timer = 0;
			int rand = Random.Range (0, 3);
			if (!hasCube [rand]) {
				Vector3 pos = new Vector3 (poss [rand], 4, 0);
				objects [rand] = (GameObject)GameObject.Instantiate (prefabs [rand], pos, Quaternion.identity);
				hasCube [rand] = true;
			}
		}
		int index = 0;
		while (index < 3) {
			if (hasCube[index] && Input.GetKeyDown (keycodes[index])) {
				GameObject.Destroy(objects[index]);
				hasCube[index] = false;
				Debug.Log("Precision: " + (4.5f - -objects[index].transform.localPosition.y));
			} else if (hasCube[index] && objects[index].transform.localPosition.y < -5) {
				GameObject.Destroy (objects[index]);
				hasCube[index] = false;
				Debug.Log("Precision: Miss");
			}
		index += 1;
		}

	}
}