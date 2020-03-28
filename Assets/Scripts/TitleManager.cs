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

    // Update is called once per frame
    void Update()
    {
        if (!inCredits)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.G))
            {
                SceneManager.LoadScene(1);
            }
        } else {
            if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.G))
            {
                Application.OpenURL("https://www.pirate-jam.com/");
            }
        }

        if (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.R))
        {
            ToggleCredits();
        }
    }
}
