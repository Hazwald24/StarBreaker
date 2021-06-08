using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;

    public static float initialForce = 200f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //DEBUGGING
        rb.AddForce(new Vector3(0, initialForce, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Brick brick = collision.gameObject.GetComponent<Brick>();
        if(brick != null)
        {
            brick.TakeDamage();
        }
    }
}
