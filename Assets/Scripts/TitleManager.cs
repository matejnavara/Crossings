using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject creditsObj;

    private bool inCredits = false;

    void Start()
    {
        creditsObj.SetActive(false);
    }

    public void ToggleCredits()
    {
        inCredits = !inCredits;
        creditsObj.SetActive(inCredits);
    }

    public void GoToPirateJam()
    {
        Application.OpenURL("https://www.pirate-jam.com/");
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!inCredits)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Play();
            }
        } else {
            if (Input.GetKeyDown(KeyCode.G))
            {
                GoToPirateJam();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleCredits();
        }
    }
}
