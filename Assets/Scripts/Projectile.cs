using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script handles the projectile for the Enemy Shoot scene
public class Projectile : MonoBehaviour
{
    public float speed;     // projectile speed

    private Transform player;   // player character
    private Vector2 target;     // target to shoot at


    // Start is called before the first frame update
    void Start()
    {
        // find and set the player
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // set target the projectile will move towards
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        // move the projectile towards its target position
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // if projectile reaches the target location (without hitting player), destroy it
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    // if projectile collided with player character, destroy it
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }

    // Destroys the projectile game object
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }


}
