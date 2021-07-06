using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 position;

    public Paddle paddle;


    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 paddlePos = Paddle.instance.gameObject.transform.position;

            Vector2 fingerPos = touch.position;

            if(fingerPos.x > paddlePos.x)
            {
                paddle.GetComponent<Paddle>().MovePaddle(1);
            }
            else
            {
                paddle.GetComponent<Paddle>().MovePaddle(-1);
            }
        }
    }
}
