using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// This script makes the enemy character randomly patrol within a set area range
public class Patrol : MonoBehaviour
{
    public float speed;     // movement speed
    public float startWaitTime;     // how long before moving to the next spot
    private float waitTime;         // countdown timer

    public Transform moveSpot;      // the target spot the enemy will move to

    public float minX;      // the left edge of the patrol area
    public float maxX;      // the right edge of the patrol area
    public float minY;      // the bottom edge of the patrol area
    public float maxY;      // the top edge of the patrol area



    // Start is called before the first frame update
    void Start()
    {
        // set the wait time countdown
        waitTime = startWaitTime;
        
        // put the patrol spot somewhere random within patrol area
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    // Update is called once per frame
    void Update()
    {
        // Move the enemy towards the patrol spot location
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        // Check whether enemy made it (close) to the patrol spot
        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            // if enemy has waited the set waiting time at patrol location, move the patrol spot
            // to a new random location and reset the waiting countdown timer
            if (waitTime <= 0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY,maxY));
                waitTime = startWaitTime;
            }
            // if the waiting time hasn't passed yet, don't move the enemy from patrol location and
            // continue counting down time waited at patrol location
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }
}
