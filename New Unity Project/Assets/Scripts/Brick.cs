using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public int health = 1;
    public int score = 50;
    public float speed;


    //BrickSpawner brickSpawner = GameManager.instance.GetComponent<BrickSpawner>();

    void Start()
    {
        //Add the brick to the game manager
        GameManager.instance.AddBrick(gameObject);
    }

    public void TakeDamage()
    {
        health--;
        if(health <= 0)
        {
            //Create particles

            //Report to game manager
            GameManager.instance.RemoveBrick(gameObject);
            //Report to score manager
            ScoreManager.instance.AddScore(score);
            //Destroy brick
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        speed = GameManager.instance.GetSpeed();
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Paddle paddle = collision.gameObject.GetComponent<Paddle>();
        if (paddle != null)
        {
            paddle.TakeDamage();
        }
    }

}
