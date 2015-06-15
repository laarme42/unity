using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {
	private bool isFlapping = false;
	private float FlappingStart = 0;
	private int score = 0;
	private float timer = 0;
	public GameObject PipeImage;
	static public float speed = -0.04F;
	private bool waitingnextpipe = false;
	static public bool end = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Check si on continue a monter (remanence du mouvement)
		if (isFlapping == true) {
			if (FlappingStart >= 0) {
				transform.Translate(0, +0.15f, 0);
				FlappingStart -= 1;
			}
			else
				isFlapping = false;
		}
		// Input space
		if (Input.GetKeyDown ("space")) {
			isFlapping = true;
			transform.Translate(0, +0.2f, 0);
			FlappingStart = 7;
		}
		// Si space n'a pas ete presse on descend
		else transform.Translate (0, -0.07f, 0);
		if (transform.position.x >= (PipeImage.transform.position.x + 0.4) && (waitingnextpipe == false)) {
			score += 5;
//			public float speed par defaut = -0.04F;
			speed -= 0.02F;
			waitingnextpipe = true;
		}
		if (transform.position.x < (PipeImage.transform.position.x - 0.4))
			waitingnextpipe = false;
		// Check limites basses = -0.7, limites pipes y entre 0.5 et 1.5 puis limite largeur du pipe, le bird se trouve entre -0.4 et +0.4 de la pos x du pipe
		//		Debug.Log ("(transform.position.y " + (transform.position.y) + "\ntransform.position.x " + (transform.position.x) + "\nPipeImage.transform.position.y " + (PipeImage.transform.position.y));
		if ((transform.position.y < -0.7) || (((transform.position.y > 1.5) || (transform.position.y < 0.5)) && ((transform.position.x > (PipeImage.transform.position.x - 0.3)) && transform.position.x < (PipeImage.transform.position.x + 0.3))))
		{
			end = true;
			GameObject.Destroy (gameObject);
			Debug.Log("Score: " + score + "\nTime: " + Mathf.RoundToInt(timer) + "s");
		}
		timer += Time.deltaTime;
	}
}
