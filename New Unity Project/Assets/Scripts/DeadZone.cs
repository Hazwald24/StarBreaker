using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Ball"))
        {
            GameManager.instance.LostBall(col.gameObject);
        }
    }
}
