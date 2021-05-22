using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

    [HideInInspector] public static LifeManager instance;
    [SerializeField] Image[] lifeImages;

    [SerializeField] int lives = 3;
    void Start()
    {
        instance = this;
    }
    public void AddLife()
    {
        if (lives < 3)
        {
            lives++;
            UpdateUI();
        }
    }
    public void RemoveLife()
    {
        lives--;
        UpdateUI();
        if (lives == 0)
        {
            StartCoroutine(GunController.EndGame());
        }
    }
    void UpdateUI()
    {
        for (int i = 0; i < lifeImages.Length; i++)
        {
            lifeImages[i].enabled = i < lives;
        }
    }
}
