using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public float speed; // 10

    private Rigidbody2D rBody;

    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Used for Physics
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        var vel = rBody.velocity;
        vel.x = speed;
        rBody.velocity = vel * moveHorizontal;
    }
}
