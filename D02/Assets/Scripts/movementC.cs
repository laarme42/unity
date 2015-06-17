﻿using UnityEngine;
using System.Collections;

public class movementC : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float mousePosX = Input.mousePosition.x; 
		float mousePosY = Input.mousePosition.y; 
		int scrollDistance = 5; 
		float scrollSpeed = 10;
		
		if (mousePosX < scrollDistance) 
		{ 
			transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime); 
		} 
		
		if (mousePosX >= Screen.width - scrollDistance) 
		{ 
			transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime); 
		}
		
		if (mousePosY < scrollDistance) 
		{ 
			transform.Translate(Vector3.up * -scrollSpeed * Time.deltaTime); 
		} 
		
		if (mousePosY >= Screen.height - scrollDistance) 
		{ 
			transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime); 
		}
	}
}
