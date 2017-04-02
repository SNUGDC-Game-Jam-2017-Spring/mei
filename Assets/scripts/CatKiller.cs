using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatKiller : MonoBehaviour
{
    [SerializeField] private PlatformSpawner platformSpawner;
    public bool catKilled;

	void Update () {
	    if (!catKilled)
	    {
	        if (transform.position.y < platformSpawner.MinPlatformHeight)
	        {
	            Debug.Log("Cat killed!");
	            catKilled = true;
	        }
	    }
	}
}
