using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    int scoreOnHit = 50;
    float enemyDuration = 15;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, enemyDuration);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        if (collision.collider.CompareTag("Bullet"))
        {
            ScoreCounter.AddScore(scoreOnHit);
            Destroy(gameObject);
        }
    }
}

