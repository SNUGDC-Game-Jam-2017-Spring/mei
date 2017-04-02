using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{ 
    public GameObject cat;
    public static Vector3 cameraPosition;
    public float HeightRecorder;


    void Start()
    {
        cameraPosition = transform.position;
        cameraPosition.y = 0.0f;
        HeightRecorder = 0.0f;
    }


    void Update()
    {
        var catHeight = cat.transform.position.y;

        if (catHeight > 3.0f)
        {
            if (catHeight - cameraPosition.y > 3.0f)
            {
                cameraPosition.y = catHeight - 3.0f;             
                this.transform.position = cameraPosition;
                HeightRecorder = catHeight;
            }

            else
            {
                cameraPosition.y = HeightRecorder - 3.0f;
                this.transform.position = cameraPosition;
            }
        }
        else
        {
            this.transform.position = cameraPosition;
        }
    }
}