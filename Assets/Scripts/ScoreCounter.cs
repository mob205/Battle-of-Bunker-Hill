using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour {

    TextMeshProUGUI text;
    static int score;
	// Use this for initialization
	void Start () {
        text = GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateScore();
	}
    void UpdateScore()
    {
        text.text = ProcessScore();
    }
    public static void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
    string ProcessScore()
    {
        var originalString = score.ToString();
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
