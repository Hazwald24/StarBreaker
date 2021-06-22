using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject ballPrefab;


    List<GameObject> brickList = new List<GameObject>();
    List<GameObject> ballList = new List<GameObject>();

    int lives;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ResetGame();
    }

    private void ResetGame()
    {
        CreateBall();
        lives = 3;
        //UPDATE UI
    }

    //---------------LIVES--------------------//

    void RemoveLife()
    {
        lives--;
        //UPDATE UI

        //LOSE CONDITION
        if (lives == 0)
        {
            print("GAME OVER");
            return;
        }

        CreateBall();
        //RESET PADDLE POSITION
        Paddle.instance.ResetPaddle();
    }

    public void LostBall(GameObject ball)
    {
        ballList.Remove(ball);
        Destroy(ball);

        if(ballList.Count == 0)
        {
            RemoveLife();
        }
    }

    //---------------BRICKS--------------------//

    public void AddBrick(GameObject brick)
    {
        brickList.Add(brick);
    }

    public void RemoveBrick(GameObject brick)
    {
        brickList.Remove(brick);
        //WINNING CONDITION
        if(brickList.Count == 0)
        {
            print("You Won!");
        }
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
        if (Input.GetKeyDown(KeyCode.Space) && ballList.Count > 0)
        {
            if(ballList[0] != null && !ballList[0].GetComponent<Ball>().BallStarted())
            {
                StartBall();
            }
        }
    }


}
