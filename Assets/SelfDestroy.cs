﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
