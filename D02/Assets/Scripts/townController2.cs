using UnityEngine;
using System.Collections;

public class townController2 : MonoBehaviour {

	public delegate void			TownEvent();
	public static event TownEvent	HumanDestroy;
	public static event TownEvent	OrcDestroy;
	public int						life;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (life <= 0) {
			GameObject.Destroy(gameObject);
			if (tag == "human_town") {
				HumanDestroy();
			} else {
				OrcDestroy();
			}
		}
	}
}