using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text finalScoreText;
    public Text[] letterTexts;
    public GameObject  lettersObj;
    public LeaderboardGUI lb;

    private GameManager gm;
    private Animator anim;
    private string[] letters;
    private string name = "";
    private int letterPos = 0;
    private int selectingLetter = 0;
    private bool nameSet = false;
    private bool isHighScore = false;
    private bool countScore = false;
    private int finalScore = 0;

    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        letters = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        lettersObj.SetActive(false);
    }

    public void CountToScore()
    {
        finalScore = gm.getScore();
        int lbScore = Leaderboard.GetEntry(Leaderboard.EntryCount - 1).score;
        isHighScore = finalScore > lbScore;
        countScore = true;
        StartCoroutine(IncrementScore());
    }

    public void PlayAgain()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void CycleLetter()
    {   
        letterPos += 1;
        if (letterPos > 25) letterPos = 0;
        letterTexts[selectingLetter].text = letters[letterPos];
    }

    public void ConfirmLetter()
    {
        name += letters[letterPos];
        letterPos = 0;
        letterTexts[selectingLetter].color = Color.green;
        selectingLetter += 1;
    }

    void ConfirmName()
    {
        Leaderboard.Record(name, finalScore);
        nameSet = true;
        DisplayLB();
    }

    void DisplayLB()
    {
        anim.Play("Leaderboard");
        lb.DrawLeaderboard();
    }

    IEnumerator IncrementScore()
    {
        for (int i = 0; i <= finalScore; ++i)
        {
            finalScoreText.text = i.ToString();
            yield return new WaitForSeconds(0.05f);
        }
        if (isHighScore)
        {
            lettersObj.SetActive(true);
        } else {
            yield return new WaitForSeconds(1.3f);
            DisplayLB();
        }
        countScore = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHighScore && !countScore && !nameSet)
        {
            if (selectingLetter > 2)
            {
                ConfirmName();
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                ConfirmLetter();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                CycleLetter();
            }
        }
        
        if (!isHighScore && !countScore) {
            if (Input.GetKeyDown(KeyCode.G))
            {
                PlayAgain();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                BackToMenu();
            }
        }
    }
}
