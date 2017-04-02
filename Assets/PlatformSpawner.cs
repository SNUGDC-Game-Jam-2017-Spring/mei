using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour {
    public enum SceneState {
        Easy, Hard
    }
    public SceneState State {get; set;}

    // initial spawn position is extracted from this gameobject
    [SerializeField] private GameObject spawnStartPositionObj;

    // left and right wall (to check collision)
    [SerializeField] private GameObject leftWall;
    [SerializeField] private GameObject rightWall;

    [SerializeField] private float randomWalkMax;
    [SerializeField] private float randomWalkMaxIncrement;
    [SerializeField] private float spawnPosIncrementY;

    [SerializeField] private Camera camera;

    private Queue<GameObject> latestPlatforms = new Queue<GameObject>();
    public float MaxPlatformHeight { get; private set; }
    public float MinPlatformHeight { get; private set; }

    private float spawnPosX;
    private float spawnPosY;
    private float sceneBoundLeft;
    private float sceneBoundRight;
    private int numPlatforms;

    float timer = 0.0f;

    public GameObject platformPrefab;

    void Awake()
    {
        spawnPosX = 0.0f;
        spawnPosY = spawnStartPositionObj.transform.position.y;
        sceneBoundLeft = leftWall.transform.position.x;
        sceneBoundRight = rightWall.transform.position.x;
        Bounds screenBounds = camera.OrthographicBounds();
        MinPlatformHeight = screenBounds.center.y - screenBounds.size.y / 2 + 0.5f;
        MaxPlatformHeight = screenBounds.center.y + screenBounds.size.y / 2 + 0.5f;
    }

    void Start()
    {
        SpawnNextPlatforms(10);
    }

    void Update()
    {
        Bounds screenBounds = camera.OrthographicBounds();
        while (MaxPlatformHeight < screenBounds.center.y + screenBounds.size.y/2 + 1.0f)
        {
            SpawnPlatform();
        }
        while (MinPlatformHeight < screenBounds.center.y - screenBounds.size.y/2 - 1.0f)
        {
            RemovePlatform();
        }
    }

    public void SpawnNextPlatforms(int numPlatforms)
    {
        for (int i = 0; i < numPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    public GameObject SpawnPlatform()
    {
        spawnPosX += Random.Range(-randomWalkMax, randomWalkMax);
        if (spawnPosX < sceneBoundLeft)
        {
            float bounce = sceneBoundLeft - spawnPosX;
            spawnPosX += 2 * bounce;
        }
        else if (spawnPosX > sceneBoundRight)
        {
            float bounce = spawnPosX - sceneBoundRight;
            spawnPosX -= 2 * bounce;
        }

        spawnPosY += spawnPosIncrementY;

        GameObject platform = Instantiate(platformPrefab, new Vector3(spawnPosX, spawnPosY, 0.0f), Quaternion.identity);
        platform.transform.parent = transform;
        latestPlatforms.Enqueue(platform);
        numPlatforms++;

        randomWalkMax += randomWalkMaxIncrement;

        MaxPlatformHeight = spawnPosY;

        return platform;
    }

    public void RemovePlatform()
    {
        if (latestPlatforms.Count > 0)
        {
            GameObject bottomPlatform = latestPlatforms.Dequeue();
            Destroy(bottomPlatform);
            if (latestPlatforms.Count > 0)
            {
                MinPlatformHeight = latestPlatforms.Peek().transform.position.y;
            }
        }
    }
}
