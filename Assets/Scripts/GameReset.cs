using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameReset : MonoBehaviour {

    [SerializeField] float gameOverDelay = 2f;

    bool hasCheckedForEnd;
    int bulletCount;
	// Use this for initialization
	void Start () {
        bulletCount = GunController.bulletCount;
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        CheckBulletCount();
	}
    void CheckBulletCount()
    {
        if((bulletCount <= 0) && (!hasCheckedForEnd))
        {
            Invoke("StartEndSequence", gameOverDelay);
            hasCheckedForEnd = true;
        }
    }
    void StartEndSequence()
    {
        if(bulletCount > 0) {
            hasCheckedForEnd = false;
            return;
        }
       

    }
    
}
