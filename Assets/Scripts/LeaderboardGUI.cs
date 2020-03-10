using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardGUI : MonoBehaviour {

    public Font font;
    public GameObject scoreObj;

    public void DrawLeaderboard()
    {
        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine()
    {
        for (int i = 0; i < Leaderboard.EntryCount; ++i) {
            var entry = Leaderboard.GetEntry(i);
            GameObject score = Instantiate(scoreObj, transform.position, transform.rotation);
            score.transform.SetParent(transform, false);
            score.transform.localPosition = new Vector3(0, Screen.height/3 - (i * Screen.height/13), 0);

            TextMeshProUGUI scoreTMP = score.GetComponent<TextMeshProUGUI>();
            string scoreText;
            if (entry.score > 0)
            {
                scoreText = (i + 1) + "   " + entry.name + "  -  " + entry.score;
            } else {
                scoreText = "-";
            }
            scoreTMP.text = scoreText;
            scoreTMP.fontSize = 80 - (i * 5);
            yield return new WaitForSeconds(0.5f);
        }
    }
}