using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnDirector : MonoBehaviour
{
    public GameObject introSceneCeiling;
    public PlatformSpawner platformSpawner;
    public Camera camera;

    [SerializeField] private float platformSpawnOffset;

    void Awake()
    {

    }

	void Update ()
	{
        /*
	    Bounds screenBounds = camera.OrthographicBounds();
        if (platformSpawner.MaxPlatformHeight - transform.position.y < platformSpawnOffset)
        {
            platformSpawner.SpawnNextPlatforms(10);
        }
        while (platformSpawner.MinPlatformHeight < (screenBounds.center.y - screenBounds.)
        {
            platformSpawner.RemovePlatform();
        }
        */
	}
}
