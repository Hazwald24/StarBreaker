using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brickPrefab;
   

    public float respawnTime;
    
    private Vector2 screenBounds;
    private Vector2 pos1, pos2, pos3, pos4;
    
    private int posNum;

    private float timer;
    public float speed;

    private float timeInterval = 25f;

    void Start()
    {
        
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        pos1 = new Vector2(3f * -screenBounds.x / 4f, screenBounds.y * -2);
        pos2 = new Vector2(-screenBounds.x / 4f, screenBounds.y * -2);
        pos3 = new Vector2(screenBounds.x / 4f, screenBounds.y * -2);
        pos4 = new Vector2(3f * screenBounds.x / 4f, screenBounds.y * -2);

        timer = 0;
        speed = 1f;
        respawnTime = 4f;
        SpawnEnemy();

        StartCoroutine(brickWave());
    }

    private void SpawnEnemy()
    {
        GameObject brick = Instantiate(brickPrefab) as GameObject;
        posNum = Random.Range(1, 5);
        switch (posNum){ 
            case 1:
                brick.transform.position = pos1;
                break;
            case 2:
                brick.transform.position = pos2;
                break;
            case 3:
                brick.transform.position = pos3;
                break;
            case 4:
                brick.transform.position = pos4;
                break;
        }
    }

    IEnumerator brickWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (respawnTime >= 0.25f)
        {
            timer += Time.deltaTime;
            if (timer >= timeInterval)
            {
                timer -= timeInterval;
                respawnTime /= 0.5f;
                GameManager.instance.IncreaseSpeed();
            }
        }
    }
}
