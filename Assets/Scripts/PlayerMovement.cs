using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 10F;


    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void Move()
    {
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
