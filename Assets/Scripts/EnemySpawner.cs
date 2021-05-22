using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] GameObject enemy;
    [SerializeField] Transform parent;
    [SerializeField] List<TimelineAsset> timelines;
    [SerializeField] float spawnTimer = 3f;
    [SerializeField] float timeIncreaseFactor = 0.05f;

    bool canSpawn = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //SpawnDebug();
        SpawnEnemy();
        IncreaseDifficulty();
    }
    //void SpawnDebug()
    //{
    //    if (!Debug.isDebugBuild) { return; }
    //    if (Input.GetKeyDown(KeyCode.Z))
    //    {
    //        Debug.Log("Z pressed");
    //        int index = Random.Range(0, timelines.Count);
    //        var soldier = Instantiate(enemy, parent);
    //        var director = soldier.GetComponent<PlayableDirector>();
    //        director.playableAsset = timelines[index];
    //        director.Play();
    //    }
    //}
    void SpawnEnemy()
    {
        if (!canSpawn) { return; }
        int index = Random.Range(0, timelines.Count);
        var soldier = Instantiate(enemy, parent);
        var director = soldier.GetComponent<PlayableDirector>();
        director.playableAsset = timelines[index];
        director.Play();
        ToggleSpawnable();
        Invoke("ToggleSpawnable", spawnTimer);
        
    }
    void IncreaseDifficulty()
    {
        Time.timeScale = 1 + (timeIncreaseFactor * Time.timeSinceLevelLoad);
    }
    void ToggleSpawnable()
    {
        canSpawn = !canSpawn;
    }
    
}
