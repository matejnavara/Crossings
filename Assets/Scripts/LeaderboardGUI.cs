using UnityEngine;
using TMPro;

public class LeaderboardGUI : MonoBehaviour {

    public Font font;
    public GameObject scoreObj;

    void Start()
    {
       DrawLeaderboard();
    }

    void DrawLeaderboard()
    {
        for (int i = 0; i < Leaderboard.EntryCount; ++i) {
            var entry = Leaderboard.GetEntry(i);
            GameObject score = Instantiate(scoreObj, transform.position, transform.rotation);
            TextMeshProUGUI scoreTMP = score.GetComponent<TextMeshProUGUI>();
            score.transform.SetParent(transform, false);
            score.transform.localPosition = new Vector3(0, Screen.height/3 - (i * Screen.height/13), 0);
            string scoreText = (i + 1) + "   " + entry.name + "  -  " + entry.score;
            scoreTMP.text = scoreText;
            scoreTMP.fontSize = 80 - (i * 5);
        }
    }
}