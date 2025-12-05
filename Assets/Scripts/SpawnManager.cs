using Unity.Hierarchy;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs; //Array to hold various animal prefabs
    private float frontSpawnRangeX = 20; //Range for spawning on the X axis in the front
    private float horizontalSpawnRangeX = 25; //Range for spawning on the X axis horizontally
    private float spawnPosZ = 20; //Fixed position for spawning on the Z axis
    private float startDelay = 2; //Delay before the first spawn
    private float spawnInterval = 3f; //Interval between spawns
    private float spawnRangeZ = 15;
    private Vector3 spawnPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {

        //Generate index for random animal
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        //Index to set spawnPos whether its front, left, or right
        int spawnIndex = Random.Range(0, 3);

        //Define default Animal rotation
        Quaternion animalRotation = animalPrefabs[animalIndex].transform.rotation;

        //spawn front

        spawnPos = new Vector3(Random.Range(-frontSpawnRangeX, frontSpawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalRotation);

        //spawn left

        spawnPos = new Vector3(horizontalSpawnRangeX, 0, Random.Range(1, spawnRangeZ));
        animalRotation = animalPrefabs[animalIndex].transform.rotation * Quaternion.Euler(0, 90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalRotation);

        //spawn right

        spawnPos = new Vector3(-horizontalSpawnRangeX, 0, Random.Range(1, spawnRangeZ));
        animalRotation = animalPrefabs[animalIndex].transform.rotation * Quaternion.Euler(0, -90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalRotation);

    }
}
