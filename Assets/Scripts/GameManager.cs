using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int[] lights = new int[3] { 0, 0, 0 };

    public Material[] mats;

    public bool lightA() { return lights[0] == 1; }
    public bool lightB() { return lights[1] == 1; }
    public bool lightC() { return lights[2] == 1; }

    void toggleRandomGreen()
    {
        if (!lightA || !lightB || !lightC)
        {
            int randomChoice = Rand.Range(0, 2);
            if (light[randomChoice] == 0)
            {
                light[randomChoice] = 1;
            } else {
                toggleRandomGreen();
            }
        }
    }

    void toggleRandomRed()
    {
        if (lightA || lightB || lightC)
        {
            int randomChoice = Rand.Range(0, 2);
            if (light[randomChoice] == 1)
            {
                light[randomChoice] = 0;
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
