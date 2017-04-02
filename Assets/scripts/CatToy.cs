﻿using UnityEngine;
using System.Collections;

public class CatToy : MonoBehaviour
{
    private Vector3 mousePosition;
    Ray ray;

    
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Renderer>().enabled=true;
        }

        else if (Input.GetMouseButton(0))
        {
            GetComponent<Renderer>().enabled = false;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            transform.position = ray.origin;
        }
        
    }
}

