using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour {

    static int score;
    static int highscore;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType<ScoreHolder>().Length >= 2)
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        UpdateScores();
	}
    void UpdateScores()
    {
        score = ScoreCounter.GetScore();
        highscore = ScoreCounter.GetHighScore();
    }
    public static int GetScore()
    {
        return score;
    }
    public static int GetHighscore()
    {
        return highscore;
    }
}
