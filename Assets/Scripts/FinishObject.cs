using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the finish level object in Spy Game scene
public class FinishObject : MonoBehaviour
{
    public GameObject EndGamePanel;     // reference to the end game UI panel

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if player triggers the finish object, freeze game and activate game over UI panel (win)
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0.00f;
            EndGamePanel.SetActive(true);
        }
    }
}
