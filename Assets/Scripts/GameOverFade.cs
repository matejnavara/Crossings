using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverFade : MonoBehaviour
{
    public GameObject gameoverScreen;

    void Start()
    {
        gameoverScreen.SetActive(false);
    }
    public void DisplayGameover()
    {
        gameoverScreen.SetActive(true);
    }
}
