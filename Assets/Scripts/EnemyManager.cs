using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [SerializeField] int bulletsOnKill = 1;
    [SerializeField] int bonusBullets = 2;
    [SerializeField] int bonusPercent = 50;
    [SerializeField] int scoreOnHit = 50;
    [SerializeField] float enemyDuration = 15;

	// Use this for initialization
	void Start () {
        Invoke("Despawn", enemyDuration);
	}
    void Despawn()
    {
        Destroy(gameObject);
        LifeManager.instance.RemoveLife();
    }
    public void DoDeathSequence()
    {
        var randomNumber = Random.Range(0, 100);
        if(randomNumber <= bonusPercent)
        {
            GunController.bulletCount += bonusBullets;
        }
        else
        {
            GunController.bulletCount += bulletsOnKill;
        }
        ScoreCounter.AddScore(scoreOnHit);
        LifeManager.instance.AddLife();
        Destroy(gameObject);
    }
}

