using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text finalScoreText;
    public Text[] letterTexts;

    private GameManager gm;
    private string[] letters;
    private string name = "";
    private int letterPos = 0;
    private int selectingLetter = 0;
    private bool nameSet = false;
    private bool countScore = false;
    private int score = 0;
    private int finalScore = 0;

    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        letters = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    }

    public void CountToScore()
    {
        finalScore = gm.getScore();
        countScore = true;
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
        if (countScore && score < finalScore)
        {
            score += 1;
            finalScoreText.text = score.ToString();
        }
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
