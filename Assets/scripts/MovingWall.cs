using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour {

    Vector3 wallPosition;

    void Start()
    {
        wallPosition = transform.position;
    }
    void Update () {

        wallPosition.y = CameraMovement.cameraPosition.y;
        this.transform.position = wallPosition;

	}
}
