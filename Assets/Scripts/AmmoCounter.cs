using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCounter : MonoBehaviour {

    TextMeshProUGUI text;
	// Use this for initialization
	void Start () {
        text = GetComponent<TextMeshProUGUI>();
        
	}
	
	// Update is called once per frame
	void Update () {
        UpdateCounter();
	}
    void UpdateCounter()
    {
        text.text = GunController.bulletCount + "x";
    }
}
