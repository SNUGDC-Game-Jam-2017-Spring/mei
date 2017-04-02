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
    }

    void Update()
    {
    }

    public float SpawnNextPlatforms(int numPlatforms)
    {
        GameObject lastSpawnedPlatform = null;
        for (int i = 0; i < numPlatforms; i++)
        {
            lastSpawnedPlatform = SpawnPlatform();
        }
        return lastSpawnedPlatform.transform.position.y;
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
        numPlatforms++;

        randomWalkMax += randomWalkMaxIncrement;

        return platform;
    }
}
