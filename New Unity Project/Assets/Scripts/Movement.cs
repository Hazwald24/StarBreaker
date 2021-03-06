using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
public class Movement: MonoBehaviour {  
    //variables    
    public float moveSpeed = 10;  
    public GameObject paddle;  
    private Rigidbody paddleBody;  
    private float ScreenWidth;  
    // Use this for initialization    
    void Start() {  
        ScreenWidth = Screen.width;  
        paddleBody = paddle.GetComponent<Rigidbody>();  
    }  
    // Update is called once per frame    
    void Update() {  
        int i = 0;  
        //loop over every touch found    
        while (i < Input.touchCount) {  
            if (Input.GetTouch(i).position.x > ScreenWidth / 2) {  
                //move right    
                RunCharacter(20.0f);  
            }  
            if (Input.GetTouch(i).position.x < ScreenWidth / 2) {  
                //move left    
                RunCharacter(-20.0f);
            }  
            ++i;  
        }  
    }  
    void FixedUpdate() {  
        #if UNITY_EDITOR  
        RunCharacter(Input.GetAxis("Horizontal"));  
        #endif  
    }
    private void RunCharacter(float horizontalInput)
    {
        //move player
        if (paddleBody != null)
        { 
            paddleBody.AddForce(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0));
        }
    }
} 