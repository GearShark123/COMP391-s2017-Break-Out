using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMover : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rBody;
    public float fireDelta = 0.5f;
    private float nextFire = 1.09f;
    private float myTime = 0.0f;

    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {            
            var vel = rBody.velocity;
            vel.y = 6;
            rBody.velocity = vel;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myTime += Time.deltaTime;
        if (myTime > nextFire)
        {
            var vel = rBody.velocity;
            vel.y = speed;
            rBody.velocity = vel;
        }
    }

    void OnCollisionEnter2D(Collision2D coll) // Velocity change on contact
    {
        if (coll.collider.CompareTag("YellowBrick") || coll.collider.CompareTag("GreenBrick") || coll.collider.CompareTag("OrangeBrick") || coll.collider.CompareTag("RedBrick") || coll.collider.CompareTag("BorderTop"))
        {
            Destroy(gameObject);
        }
    }
}
