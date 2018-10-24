using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuitGameScoreCounter : MonoBehaviour {

    [SerializeField] GameObject highscoreObject;

    TextMeshProUGUI highscoreText;
    TextMeshProUGUI text;
    static int highscore;
    static int score;
    void Awake()
    {
        highscore = ScoreHolder.GetHighscore();
        score = ScoreHolder.GetScore();
    }
    // Use this for initialization
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        highscoreText = highscoreObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        UpdateHighscore();
    }
    void UpdateScore()
    {
        text.text = "SCORE: " + ProcessScore(score);
    }
    void UpdateHighscore()
    {
        if (score > highscore)
        {
            highscore = score;
        }
        highscoreText.text = "HIGH SCORE: " + ProcessScore(highscore);
    }

    string ProcessScore(int unprocessed)
    {
        var originalString = unprocessed.ToString();
        var newString = "";
        if (originalString.Length < 8)
        {
            newString = GetZeroes(originalString) + originalString;
        }
        return newString;
    }

    string GetZeroes(string originalString)
    {
        var zeroString = "00000000";
        for (int i = 0; i < originalString.Length; i++)
        {
            zeroString = zeroString.Remove(0, 1);
        }
        return zeroString;
    }
}
