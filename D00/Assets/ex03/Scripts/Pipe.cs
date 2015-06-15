using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Bird.end)
			GameObject.Destroy (gameObject);
		if (transform.localPosition.x < -5) {
			transform.position = new Vector3(2.8F, 1.1F, 0);
		}
		transform.Translate(Bird.speed, 0, 0F);
	}
}