using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrickGreen : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll) // Velocity change on contact
    {
        if (coll.collider.CompareTag("Ball"))
        {
            string BorderName = transform.tag;
            GameManager.Score(BorderName);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        else if (coll.collider.CompareTag("Missile"))
        {
            string BorderName = transform.tag;
            GameManager.Score(BorderName);
            gameObject.SetActive(false);
        }
    }

    //void BrickResest()
    //{
    //    gameObject.SetActive(true);
    //}
}
