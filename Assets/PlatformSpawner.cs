using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour {
    public enum MapState {
        Intro, Easy, Hard
    }
    public MapState State {get; set;}

    float randomWalkMax = 3.0f;
    float createInterval = 3.0f;
    float spawnPosX = 0.0f;
    float spawnPosY = 0.0f;
    float spawnPosIncrementY = 1.0f;

    Random random = new Random();
    float timer = 0.0f;

    public GameObject platformPrefab;

    void Start()
    {

    }

    void Update()
    {
        if (State != MapState.Intro) {
            float dt = Time.deltaTime;
            timer += dt;
            if (timer >= createInterval) {
                spawnPosX += Random.Range(-randomWalkMax, randomWalkMax);
                spawnPosY += spawnPosIncrementY;
                timer = 0.0f;
            }
            SpawnPlatform();
        }
    }

    public GameObject SpawnPlatform()
    {
        GameObject platform = Instantiate(platformPrefab, new Vector3(spawnPosX, spawnPosY, 0.0f), Quaternion.identity);
        return platform;
    }
}
