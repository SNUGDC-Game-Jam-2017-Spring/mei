using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float breakDelay = 3.0f;
    private float counter = 0.0f;
    private bool isTouched = false;

	void Awake() {
		
	}
	
	void Update()
	{
	    if (isTouched)
	    {
	        counter += Time.deltaTime;
	        if (counter >= breakDelay)
	        {
	            Destroy(gameObject);
	        }
	    }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && col.collider is BoxCollider2D)
        {
            isTouched = true;
        }
    }
}
