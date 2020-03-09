using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text finalScore;
    public Text[] letterTexts;

    private GameManager gm;
    private string[] letters;
    private int letterPos = 0;
    private int selectingLetter = 0;
    private string name = "";
    private bool nameSet = false;

    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        letters = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    }

    void CycleLetter()
    {   
        letterPos += 1;
        if (letterPos > 25) letterPos = 0;
        letterTexts[selectingLetter].text = letters[letterPos];
    }

    void ConfirmLetter()
    {
        name += letters[letterPos];
        letterPos = 0;
        letterTexts[selectingLetter].color = Color.green;
        selectingLetter += 1;
    }

    void ConfirmName()
    {
        Debug.Log("Name: " + name);
        nameSet = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!nameSet)
        {
            if (selectingLetter > 2)
            {
                ConfirmName();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                ConfirmLetter();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                CycleLetter();
            }
        }
    }
}
