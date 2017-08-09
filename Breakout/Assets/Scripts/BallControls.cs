using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ball needs to appear when game start!

public class BallControls : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Vector2 vel;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gameObject.GetComponent<Renderer>().enabled = false;
        //gameObject.SetActive(false);
        Invoke("BallDirection", 2.0f);         // 2 seconds before ball starts moving
    }

    // To choose a random direction
    void BallDirection()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        //gameObject.SetActive(true);
        int rand = Random.Range(0, 2); // 0 <= x < 2
        if (rand == 0)
        {
            rb2d.AddForce(new Vector2(20.0f, -15.0f));
        }
        else 
        {
            rb2d.AddForce(new Vector2(-20.0f, -15.0f));
        }
    }

    void BallReset()
    {
        vel.y = 0.0f;
        vel.x = 0.0f;
        rb2d.velocity = vel;
        gameObject.transform.position = new Vector2(0.0f, 0.0f);
    }

    void RestartGame()
    {
        BallReset();
        Invoke("BallDirection", 1.0f);
    }

    void OnCollisionEnter2D(Collision2D coll) // Velocity change on contact
    {
        if (coll.collider.CompareTag("Player"))
        {
            //vel.x = rb2d.velocity.x/1.8f;
            //vel.x = (rb2d.velocity.x / 2.0f) + (coll.collider.attachedRigidbody.velocity.x / 3.0f);
            vel.x = rb2d.velocity.x;
            vel.y = rb2d.velocity.y;
            rb2d.velocity = vel;
        }     
    }
}
