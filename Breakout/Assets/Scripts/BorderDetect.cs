using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderDetect : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Ball")
        {
            string BorderName = transform.name;
            GameManager.Score(BorderName);
            hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}
