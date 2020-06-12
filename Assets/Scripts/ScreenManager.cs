using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.00f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToEnemyFollow()
    {
        SceneManager.LoadScene("EnemyFollow");
    }
    public void GoToEnemyShoot()
    {
        SceneManager.LoadScene("EnemyShoot");
    }
    public void GoToEnemyPatrol()
    {
        SceneManager.LoadScene("EnemyPatrol");
    }
    public void GoToSpyGame()
    {
        SceneManager.LoadScene("SpyGame");
    }
}
