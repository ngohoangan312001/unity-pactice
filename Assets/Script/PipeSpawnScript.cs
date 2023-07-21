using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2.5f;
    public float maxSpawnRate = 1;
    public float timer = 0;
    public float heighOffset = 3;
    public BirdScript bird;
    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        SpawnPipe();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If timer not equal to spawn rate then plus it with delta time
        // else spawn pipe
        // => if fps is 50, timer will + 0.02 each frame => 50 frame timer will = 1 => 2s will spawn 1 pipe
        if (bird.birdIsAlive)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                SpawnPipe();
                timer = 0;
            }
        }
    }

    void SpawnPipe()
    {
        // Create a lowest and highest point from the object potion
        float lowestPoint = transform.position.y - heighOffset;
        float highestPoint = transform.position.y + heighOffset;

        // Generate random heigh value for Pipe spawning while X and Z unchange 
        Vector3 randomHeigh = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0);

        // Spawn pipe 
        Instantiate(pipe, randomHeigh, transform.rotation);

        if (spawnRate > maxSpawnRate)
        {
            spawnRate -= 0.05f;
        }
    }
}
