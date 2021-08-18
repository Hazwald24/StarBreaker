using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using.UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public void Setup(int lives)
    {
        gameObject.SetActive(true);


    }


    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

