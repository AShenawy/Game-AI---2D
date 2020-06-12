using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script handles the switching between game scenes
public class ScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Set time flow to normal speed
        Time.timeScale = 1.00f;
    }

    // Go to the Main Menu scene
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Go to the Enemy Follow scene
    public void GoToEnemyFollow()
    {
        SceneManager.LoadScene("EnemyFollow");
    }

    // Go to the Enemy Shoot scene
    public void GoToEnemyShoot()
    {
        SceneManager.LoadScene("EnemyShoot");
    }

    // Go to the Enemy Patrol scene
    public void GoToEnemyPatrol()
    {
        SceneManager.LoadScene("EnemyPatrol");
    }

    // Go to the Spy Game scene
    public void GoToSpyGame()
    {
        SceneManager.LoadScene("SpyGame");
    }
}
