using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int lifeCounter;
    public static int playerScore = 0;
    public static int level = 1;
    public static string background = "Level 1 Background";

    [SerializeField]
    public int limit;       // 122  
    [SerializeField]
    public int limit2;      // 168 + 122 = 290
    public GUISkin layout;

    public GameObject lvl1Background;
    public GameObject lvl2Background;
    public GameObject lvl3Background;

    public GameObject lvl1;
    public GameObject lvl2;
    public GameObject lvl3;

    Transform theBall;

    void Start()
    {
        print(level);

        theBall = GameObject.FindGameObjectWithTag("Ball").transform;

        lvl1Background.SetActive(false);
        lvl2Background.SetActive(false);
        lvl3Background.SetActive(false);
        lvl1.SetActive(false);
        lvl2.SetActive(false);
        lvl3.SetActive(false);

        if (background == "Level 1 Background")
        {
            lvl1Background.SetActive(true);
            lvl2Background.SetActive(false);
            lvl3Background.SetActive(false);
            lvl1.SetActive(true);
            lvl2.SetActive(false);
            lvl3.SetActive(false);
        }
        else if (background == "Level 2 Background")
        {
            lvl2Background.SetActive(true);
            lvl1Background.SetActive(false);
            lvl3Background.SetActive(false);
            lvl2.SetActive(true);
            lvl1.SetActive(false);
            lvl3.SetActive(false);
        }
        else if (background == "Level 3 Background")
        {
            lvl3Background.SetActive(true);
            lvl2Background.SetActive(false);
            lvl1Background.SetActive(false);
            lvl3.SetActive(true);
            lvl2.SetActive(false);
            lvl1.SetActive(false);
        }
    }

    // Point depending on wall hit
    public static void Score(string borderID)
    {
        if (borderID == "BorderBottom")
        {
            //counter.life++;
            lifeCounter++;
        }
        if (borderID == "YellowBrick")
        {
            playerScore++;
        }
        if (borderID == "GreenBrick")
        {
            playerScore += 3;
        }
        if (borderID == "OrangeBrick")
        {
            playerScore += 5;
        }
        if (borderID == "RedBrick")
        {
            playerScore += 7;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {                 
            level = 1;
            playerScore = 0;
            lifeCounter = 1;
            background = "Level 1 Background";
            SceneManager.LoadScene("Breakout (Hard)");
        }
        else if (Input.GetKeyUp("2"))
        {
            level = 2;
            playerScore = 122;
            lifeCounter = 1;
            background = "Level 2 Background";
            SceneManager.LoadScene("Breakout (Hard)");
        }
        else if (Input.GetKeyUp("3"))
        {
            level = 3;
            playerScore = 290;
            lifeCounter = 1;
            background = "Level 3 Background";
            SceneManager.LoadScene("Breakout (Hard)");
        }
    }

    void FixedUpdate()
    {
        if (playerScore >= limit && level == 1)
        {
            level++;
            background = "Level 2 Background";
            SceneManager.LoadScene("Breakout (Hard)");
        }
        else if (playerScore >= limit2 && level == 2)
        {
            level++;
            background = "Level 3 Background";
            SceneManager.LoadScene("Breakout (Hard)");
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + lifeCounter);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + playerScore);
        GUI.Label(new Rect(Screen.width / 2, 20, 100, 100), "" + level);

        if (lifeCounter == 4)
        {
            GUI.Label(new Rect(Screen.width / 2 - 30, 200, 2000, 1000), "Game Over");
            theBall.gameObject.SendMessage("BallReset", null, SendMessageOptions.RequireReceiver);
            //theBall.gameObject.SendMessage("BrickReset", null, SendMessageOptions.RequireReceiver);
            if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
            {
                level = 1;
                playerScore = 0;
                lifeCounter = 1;
                background = "Level 1 Background";
                theBall.gameObject.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
                SceneManager.LoadScene("Breakout (Hard)");
            }
        }
    }
}
