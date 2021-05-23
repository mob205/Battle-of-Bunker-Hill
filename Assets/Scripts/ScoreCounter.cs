using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour {

    [SerializeField] GameObject highscoreObject;
    [SerializeField] AudioSource scoreSound;

    TextMeshProUGUI highscoreText;
    TextMeshProUGUI text;
    static int highscore;
    static int score;

    static AudioSource sound;
    void Awake()
    {
        score = 0;
    }
    // Use this for initialization
    void Start () {
        text = GetComponent<TextMeshProUGUI>();
        highscoreText = highscoreObject.GetComponent<TextMeshProUGUI>();
        sound = scoreSound;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateScore();
        UpdateHighscore();
	}
    void UpdateScore()
    {
        text.text = ProcessScore(score);
    }
    void UpdateHighscore()
    {
        if(score > highscore)
        {
            highscore = score;
        }
        highscoreText.text = "HIGH SCORE: " + ProcessScore(highscore);
    }
    public static void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        sound.Play();
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
    public static int GetScore()
    {
        return score;
    }
    public static int GetHighScore()
    {
        return highscore;
    }
}
