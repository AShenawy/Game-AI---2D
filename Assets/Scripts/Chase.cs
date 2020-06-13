using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script makes the enemy character chase the player in Spy Game scene
public class Chase : MonoBehaviour
{
    public float speed;     // enemy move speed

    [SerializeField]
    private bool isChasing = false;     // set whether enemy is chasing player or not

    private Transform player;       // reference to player character

    public GameObject gameOverPanel;    // reference to game over UI panel

    private Patrol patrolScript;    // reference to enemy patrol script


    // Start is called before the first frame update
    void Start()
    {
        // find the patrol script component on the enemy character
        patrolScript = this.GetComponent<Patrol>();
    }

    // Update is called once per frame
    void Update()
    {
        // if isChasing bool is set to true, chase the player
        if (isChasing)
        {
            ChaseThePlayer();
        }
    }

    void ChaseThePlayer()
    {
        // make the enemy run after player character
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        // if character tagged player enters enemy trigger radius, enemy sets the player as their chase target, 
        // sets chasing to true, and then disables the patrol script to stop patrolling
        if (target.CompareTag("Player"))
        {
            player = target.transform;
            isChasing = true;
            patrolScript.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D target)
    {
        // if player exits the trigger radius of enemy, enemy stops chasing player and
        // reenables patrolling script
        if (target.CompareTag("Player"))
        {
            isChasing = false;
            patrolScript.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if enemy collides with player character, freeze game and activate game over UI panel (loss)
        if (collision.transform.CompareTag("Player"))
        {
            Time.timeScale = 0.00f;
            gameOverPanel.SetActive(true);
        }
    }
}
