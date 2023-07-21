using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -17.75f;
    public BirdScript bird;
    public RepeatBackgroundScript background;
    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        background = GameObject.FindGameObjectWithTag("Background").GetComponent<RepeatBackgroundScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.birdIsAlive)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= deadZone)
        {
            Destroy(gameObject);
            background.GenerateBackground();
        }
    }

}
