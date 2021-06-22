using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public int health = 1;
    public int score = 50;

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

            //Destroy brick
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.position -= new Vector3(0, 1 * Time.deltaTime, 0);
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
