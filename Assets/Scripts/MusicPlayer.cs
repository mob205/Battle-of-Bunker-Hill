using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

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
		
	}
}
