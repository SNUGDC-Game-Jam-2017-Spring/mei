using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroScript : MonoBehaviour {

    //public GameObject cat;
    Animator anim;
    CatAggro catAggro;

	// Use this for initialization
	void Start () {
        
        anim = GetComponentInChildren<Animator>();
        catAggro = GetComponent<CatAggro>();
    }
	
	// Update is called once per frame
	void Update () {
        if (catAggro.gotAggro.State)
        {
            anim.SetBool("gotAggro", true);
        }
        else
        {
            if (anim.GetBool("gotAggro"))
            {
                anim.SetBool("gotAggro", false);
            }
        }
	}
}
