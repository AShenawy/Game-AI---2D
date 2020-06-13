using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script makes an enemy character follow player and shoot projectiles at them
public class Enemy : MonoBehaviour
{
    public float speed;     // enemy movement speed
    public float stoppingDistance;      // when following target, how far away from it the enemy should stop
    public float retreatDistance;       // when approached by target, at what distance the enemy should back away from target

    private Transform player;       // The player character to follow/shoot at

    private float timeBtwShots;     // time countdown between each shot
    public float startTimeBtwShots;     // set time between shots in inspector

    public GameObject projectile;       // the projectile object to shoot

    // Start is called before the first frame update
    void Start()
    {
        // Find and set the player character
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        // set time between shots initial value
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        // If target distance to enemy is more then stopping distance, start following target 
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        // if distance between enemy and target is less than stopping distance, but still more than retreat distance, then stand still
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && (Vector2.Distance(transform.position, player.position) > retreatDistance))
        {
            transform.position = this.transform.position;

        }
        // if distance between enemy and target is less than retreat distance, back away from target
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        // if time between shots passed set waiting time, then shoot and reset shooting timer
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);     // create a projectile instance at enemy location
            timeBtwShots = startTimeBtwShots;       // reset countdown timer
        }
        // if set time between shots hasn't passed yet, don't shoot yet and continue with timer countdown
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
}
