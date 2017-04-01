using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnDirector : MonoBehaviour
{
    public GameObject introSceneCeiling;
    public PlatformSpawner platformSpawner;

    [SerializeField] private float platformSpawnOffset;

    private float lastSpawnedHeight;

    void Start()
    {
    }

	void Update () {
	    if (transform.position.y > introSceneCeiling.transform.position.y)
	    {
	        platformSpawner.State = PlatformSpawner.SceneState.Easy;
	    }

        if (lastSpawnedHeight - transform.position.y < platformSpawnOffset)
        {
            lastSpawnedHeight = platformSpawner.SpawnNextPlatforms(10);
        }
	}
}
