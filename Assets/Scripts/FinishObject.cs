using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishObject : MonoBehaviour
{
    public GameObject EndGamePanel;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0.00f;
            EndGamePanel.active = true;
        }
    }
}
