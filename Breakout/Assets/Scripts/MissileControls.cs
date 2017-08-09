using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControls : MonoBehaviour
{
    public Transform missileSpawn;
    public GameObject missile;
    public GameObject missilePicture;
    public float speed; // 10
    public float fireDelta = 0.5f;
    private float nextFire = 2.0f;
    private float myTime = 5.0f;

    private Rigidbody2D rBody;

    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        missilePicture.SetActive(true);
    }

    void MissileReset()
    {
        missilePicture.SetActive(true);
    }

    void Update()
    {
        myTime += Time.deltaTime;

        float moveHorizontal = Input.GetAxis("Horizontal");
        var vel = rBody.velocity;
        vel.x = speed;
        rBody.velocity = vel * moveHorizontal;

        if (myTime > nextFire)
        {
            missilePicture.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && myTime > nextFire)
        {
            missilePicture.SetActive(false);
            Instantiate(missile, missileSpawn.position, missileSpawn.rotation);
            myTime = 0.0f;
        }
    }
}
