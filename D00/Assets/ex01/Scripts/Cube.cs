using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {
	
	private int speed;
	
	void Start () {
		speed = Random.Range(3, 6);
	}
	
	// Update is called once per frame
	void Update () {

		float translation = Time.deltaTime * speed;
		transform.Translate (0, -translation, 0);
	}
}