using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public Material[] mats;
    public BoxCollider[] waitZones;
    public BoxCollider[] returnWaitZones;

    public Text scoreText;
    public Text livesText;
    public GameObject rushObj;
    public GameObject blackScreen;
    public int crossers = 50;

    private int[] lights = new int[3] { 0, 0, 0 };
    private int score = 0;
    private bool isRushHour = false;
    private bool isGameOver = false;

    public bool lightA() { return lights[0] == 1; }
    public bool lightB() { return lights[1] == 1; }
    public bool lightC() { return lights[2] == 1; }

    public int getScore() { return score; }
    public int getLives() { return crossers; }

    void Start()
    {
        score = 0;
        mats[0].color = Color.red;
        mats[1].color = Color.red;
        mats[2].color = Color.red;
        rushObj.SetActive(false);
    }

    public bool getRushHour() { return isRushHour; }
    public bool getGameOver() { return isGameOver; }

    public void SuccessfulCrossing()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    public void UnsuccessfulCrossing()
    {
        crossers -= 1;
        livesText.text = crossers.ToString();
    }

    void ToggleRandomGreen()
    {
        if (!lightA() || !lightB() || !lightC())
        {
            int randomChoice = Random.Range(0, 3);
            if (lights[randomChoice] == 0)
            {
                lights[randomChoice] = 1;
                mats[randomChoice].color = Color.green;
                waitZones[randomChoice].isTrigger = false;
                returnWaitZones[randomChoice].isTrigger = false;
            } else {
                ToggleRandomGreen();
            }
        }
    }

    void ToggleRandomRed()
    {
        if (lightA() || lightB() || lightC())
        {
            int randomChoice = Random.Range(0, 3);
            if (lights[randomChoice] == 1)
            {
                lights[randomChoice] = 0;
                mats[randomChoice].color = Color.red;
                waitZones[randomChoice].isTrigger = true;
                returnWaitZones[randomChoice].isTrigger = true;
            } else {
                ToggleRandomRed();
            }
        }
    }

    void RushHour()
    {
        isRushHour = true;
        rushObj.SetActive(true);
    }

    void GameOver()
    {
        isGameOver = true;
        blackScreen.GetComponent<Animator>().Play("FadeOut");
        // ui.FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (crossers < 10 && !isRushHour)
            {
                RushHour();
            }

            if (crossers == 0)
            {
                GameOver();
            }

            if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.G))
            {
                ToggleRandomGreen();
            }

            if (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.R))
            {
                ToggleRandomRed();
            }
        }
        
    }
}
