using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength = 10;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.score == logic.superScore)
        {
            animator.SetTrigger("SuperScore");
        }

        if (logic.score == logic.rainbowScore)
        {
            animator.SetTrigger("RainbowScore");
        }

        if (!birdIsAlive)
        {
            animator.SetTrigger("GameOver");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            logic.SubMenu();
        }

        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        if(transform.position.y < -4)
        {
            logic.GameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            logic.GameOver();
        }

        birdIsAlive = false;
    }
}
