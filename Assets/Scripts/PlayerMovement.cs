using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script makes the player character move using WASD keys
public class PlayerMovement : MonoBehaviour
{
    // Set the player move speed
    public float MoveSpeed = 10f;


    // Update is called once per frame
    void Update()
    {
        Move();     // Move the player
    }


    private void Move()
    {
        // Move player based on direction input

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position = new Vector2(this.transform.position.x,this.transform.position.y + (MoveSpeed * Time.deltaTime));
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - (MoveSpeed * Time.deltaTime));
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position = new Vector2(this.transform.position.x - (MoveSpeed * Time.deltaTime), this.transform.position.y);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position = new Vector2(this.transform.position.x + (MoveSpeed * Time.deltaTime), this.transform.position.y);
        }
    }

}
