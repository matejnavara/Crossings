﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public Material[] mats;
    public BoxCollider[] waitZones;
    private int[] lights = new int[3] { 0, 0, 0 };
    private int score = 0;

    public bool lightA() { return lights[0] == 1; }
    public bool lightB() { return lights[1] == 1; }
    public bool lightC() { return lights[2] == 1; }

    void Start()
    {
        score = 0;
        mats[0].color = Color.red;
        mats[1].color = Color.red;
        mats[2].color = Color.red;
    }

    public void SuccessfulCrossing()
    {
        score += 1;
    }

    void toggleRandomGreen()
    {
        if (!lightA() || !lightB() || !lightC())
        {
            int randomChoice = Random.Range(0, 3);
            if (lights[randomChoice] == 0)
            {
                lights[randomChoice] = 1;
                mats[randomChoice].color = Color.green;
                waitZones[randomChoice].isTrigger = false;
            } else {
                toggleRandomGreen();
            }
        }
    }

    void toggleRandomRed()
    {
        if (lightA() || lightB() || lightC())
        {
            int randomChoice = Random.Range(0, 3);
            if (lights[randomChoice] == 1)
            {
                lights[randomChoice] = 0;
                mats[randomChoice].color = Color.red;
                waitZones[randomChoice].isTrigger = true;
            } else {
                toggleRandomRed();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            toggleRandomGreen();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            toggleRandomRed();
        }
        
    }
}