using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script makes an enemy character run after the player
public class EnemyFollow : MonoBehaviour
{
    public float speed;     // enemy speed
    public float stoppingDistance;      // when following target, how far away from it the enemy should stop
    public float retreatDistance;       // when approached by target, at what distance the enemy should back away from target

    private Transform target;       // The target to follow

    // Start is called before the first frame update
    void Start()
    {
        // set the target by finding player character throught their tag
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // If target distance to enemy is more then stopping distance, start following target
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        // if distance between enemy and target is less than stopping distance, but still more than retreat distance, then stand still
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && (Vector2.Distance(transform.position, target.position) > retreatDistance))
        {
            transform.position = this.transform.position;
        }
        // if distance between enemy and target is less than retreat distance, back away from target
        else if (Vector2.Distance(transform.position, transform.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }

    }
}
