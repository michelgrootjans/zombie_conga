﻿using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		Invoke("LoadLevel", 3f);
	}
	
	void LoadLevel() {
		Application.LoadLevel("LaunchScene");
	}
}
