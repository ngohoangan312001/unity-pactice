using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public static float moveSpeed = 5;
    public float maxSpeed = 15;
    public float deadZone = -10;
    public BirdScript bird;
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.birdIsAlive)
        {
            Move();
        }
        else
        {
            moveSpeed = 5;
        }
    }

    private void Move()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if (moveSpeed < maxSpeed && !logic.gameIsPause)
        {
            moveSpeed += 0.001f;
        }

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
