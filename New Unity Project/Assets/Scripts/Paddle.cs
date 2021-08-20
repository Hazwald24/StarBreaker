using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paddle : MonoBehaviour
{
    public static Paddle instance;

    public float newSize = 2f;
    [Space]
    public GameObject paddle;
    public MenuController menuController;


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
            menuController.GameOver();
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

    public void MovePaddleRight()
    {
        Debug.Log("here");
        rb.MovePosition(transform.position + new Vector3(1, 0, 0).normalized * speed * Time.fixedDeltaTime);
    }

    public void MovePaddleLeft()
    {
        Debug.Log("there");
        rb.MovePosition(transform.position + new Vector3(-1, 0, 0).normalized * speed * Time.fixedDeltaTime);
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
        
 }


