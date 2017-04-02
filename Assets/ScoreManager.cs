using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public GameObject cat;
    float catHeight = 0;
    public Text score;

	// Use this for initialization
	void Start () {
        score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        if (cat.transform.position.y > catHeight)
        {
            catHeight = cat.transform.position.y;
        }

        score.text = "Score : " + Mathf.CeilToInt(catHeight*100);


    }
}
