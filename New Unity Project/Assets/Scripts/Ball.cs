using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;

    public static float initialForce = 300f;
    bool ballStarted;

    private float time = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialForce = 300f;
        //DEBUGGING
        
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time > 5f)
        {
            initialForce += 100f;
            time -= 5f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Brick brick = collision.gameObject.GetComponent<Brick>();
        if(brick != null)
        {
            brick.TakeDamage();
        }
    }

    public void StartBall()
    {
        if (!ballStarted)
        {
            rb.isKinematic = false;
            rb.AddForce(new Vector3(initialForce, initialForce, 0));
            ballStarted = true;
            //PARENT BACK TO THE WORLD
            transform.SetParent(transform.parent.parent);
        }
    }

    public bool BallStarted()
    {
        return ballStarted;
    }
}
