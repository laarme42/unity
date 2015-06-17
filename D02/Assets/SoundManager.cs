using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance{ get; private set; }
	private AudioSource source;
	// Use this for initialization

	void Awake()
	{
		instance = this;
		source = GetComponent<AudioSource> ();
	}
	public void Play()
	{
		source.Play ();
	}
	public void Stop()
	{
		source.Stop ();
	}
	// Update is called once per frame

}
