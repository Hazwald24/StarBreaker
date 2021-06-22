using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public static Paddle instance;

    public GameObject centre, leftCap, rightCap;

    Rigidbody rb;
    BoxCollider col;

    float speed = 10f;

    public int health = 1;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();

        Resize(2f);
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            //Create particles

            //Report to game manager

            //Report to score manager

            //Destroy brick
            Destroy(gameObject);
        }
    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if(((int)h == 0) && rb.velocity != Vector3.zero)
        {
            rb.velocity = Vector3.zero;
        }
        rb.MovePosition(transform.position + new Vector3(h, 0, 0).normalized * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            float vel = Ball.initialForce;
            Vector3 hitPoint = collision.contacts[0].point;
            float difference = transform.position.x - hitPoint.x;

            if (hitPoint.x < transform.position.x)
            {
                ballRb.AddForce(new Vector3(-(Mathf.Abs(difference * 200)), vel, 0));
            }
            else
            {
                ballRb.AddForce(new Vector3(Mathf.Abs(difference * 200), vel, 0));
            }
        }
    }

    void Resize(float xScale)
    {
        Vector3 initScale = centre.transform.localScale;
        initScale.x = xScale;
        centre.transform.localScale = initScale;

        //LEFT CAP
        Vector3 leftCapPos = new Vector3(centre.transform.position.x + (xScale / 2), leftCap.transform.position.y, leftCap.transform.position.z);
        leftCap.transform.position = leftCapPos;
        
        //RIGHT CAP
        Vector3 rightCapPos = new Vector3(centre.transform.position.x - (xScale / 2), rightCap.transform.position.y, rightCap.transform.position.z);
        rightCap.transform.position = rightCapPos;

        //COLLIDER SCALE
        Vector3 colScale = initScale;
        colScale.x += 0.6f*2;

        col.size = colScale;

    }

    public void ResetPaddle()
    {
        transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y, 0);
        //Resize(newSize);

    }
}
