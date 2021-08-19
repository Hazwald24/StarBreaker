using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject ballPrefab;

    List<GameObject> brickList = new List<GameObject>();
    List<GameObject> ballList = new List<GameObject>();

    int lives;
    public Text livesText;

    public float brickSpeed;

    void Awake()
    {
        instance = this;

        ResetGame();
        brickSpeed = 1f;
    }

   

    private void ResetGame()
    {
        CreateBall();
        lives = 3;
        //UPDATE UI
        UpdateUI();
    }

    //---------------LIVES--------------------//

    void UpdateUI()
    {
        livesText.text = "Lives: " + lives.ToString("D2");
    }

    void RemoveLife()
    {
        lives--;
        //UPDATE UI
        UpdateUI();
        //LOSE CONDITION
        if (lives == 0)
        {
            Application.Quit();
            return;
        }
    }

    public void LostBall(GameObject ball)
    {
        ballList.Remove(ball);
        Destroy(ball);

        if(ballList.Count == 0)
        {
           //Do something? 
        }
        CreateBall();
    }

    //---------------BRICKS--------------------//

    public void AddBrick(GameObject brick)
    {
        brickList.Add(brick);
    }

    public void RemoveBrick(GameObject brick)
    {
        brickList.Remove(brick);
    }

    public void BrickPassed(GameObject brick)
    {
        RemoveLife();
    }

    public float GetSpeed()
    {
        return brickSpeed;
    }

    public void IncreaseSpeed()
    {
        brickSpeed *= 0.5f;
    }

    //---------------CREATE-BALL-------------------//

    void CreateBall()
    {
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = Paddle.instance.gameObject.transform.position + new Vector3(0, 1.5f, 0);
        newBall.transform.SetParent(Paddle.instance.gameObject.transform);
        newBall.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        ballList.Add(newBall);
    }

    void StartBall()
    {
        ballList[0].GetComponent<Ball>().StartBall();
    }

    private void Update()
    {
        if (ballList.Count > 0)
        {
            if(ballList[0] != null && !ballList[0].GetComponent<Ball>().BallStarted())
            {
                StartBall();
            }
        }
    }


}
