using UnityEngine;
using System.Collections;

public class moveHorizontal : MonoBehaviour {
	
	// Use this for initialization
	private bool top = false;
	//private float largeur = 3.5;
	private float offset = -3.5F;
	private bool go = false;
	private int count = -100;
	private int endtime;
	private bool first = true;
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		if (first) {
			endtime = Random.Range (-100, 0);
			first = false;
		}
		if (count == endtime)
			go = true;
		count += 1;
		if (go == true) {
			if (offset < 0 && !top) {
				transform.position += Vector3.right * Time.deltaTime;
				offset += 0.1F;
				
			} else {
				top = true;
				transform.position += Vector3.left * Time.deltaTime;
				offset -= 0.1F;
			}
			if (offset < -3.5)
				top = false;
		}
	} 
}
