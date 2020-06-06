using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    private Patrol PatrolScript;

    public float speed;

    [SerializeField]
    bool isChasing = false;

    Transform player;


    public GameObject GameOverPanel;



    // Start is called before the first frame update
    void Start()
    {
        PatrolScript = this.GetComponent<Patrol>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing)
        {
            ChaseThePlayer();
        }
        else if (!isChasing)
        {

        }
    }

    void ChaseThePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player"))
        {
            player = target.transform;
            isChasing = true;
            PatrolScript.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D target)
    {
        if (target.CompareTag("Player"))
        {
            player = target.transform;
        }
    }

    

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.CompareTag("Player"))
        {
            isChasing = false;
            PatrolScript.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0.00f;
        GameOverPanel.active = true;
    }
}
