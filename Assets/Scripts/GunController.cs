using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunController : MonoBehaviour {
    [Header("Aiming")]
    [SerializeField] Image crosshair;
    [SerializeField] float aimPointZ = 10;

    [Header("Game Settings")]
    [SerializeField] int startingBullets = 2;
    [SerializeField] int maxBullets = 5;
    [SerializeField] static float gameOverDelay = 1f;
    [SerializeField] float gunCooldown = 2;

    [Header("References")]
    [SerializeField] ParticleSystem firingParticles;
    [SerializeField] AudioSource firingSound;

    public static int bulletCount;
    Camera mainCamera;
    bool canFire;
    Vector3 aimLocation;

    // Use this for initialization
    void Start() {
        Cursor.visible = false;
        canFire = true;
        mainCamera = GetComponentInParent<Camera>();
        bulletCount = startingBullets;
    }

    // Update is called once per frame
    void Update() {
        MoveCrosshair();
        AimGun();
        FireGun();
        ClampAmmo();
    }

    void MoveCrosshair()
    {
        crosshair.rectTransform.anchoredPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }
    void AimGun() {
        aimLocation = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, aimPointZ));
        transform.LookAt(aimLocation);
    }
    void FireGun()
    {
        if (bulletCount <= 0) { return; }
        if (!canFire) { return; }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = new Ray(mainCamera.transform.position, aimLocation);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Enemy")))
            {
                var enemy = hit.collider.gameObject.GetComponent<EnemyManager>();
                if (enemy)
                {
                    enemy.DoDeathSequence();
                }
            }
            ToggleFire();
            Invoke("ToggleFire", gunCooldown);
            UseAmmo();
            firingParticles.Play();
            firingSound.Play();
        }
    }
    void UseAmmo()
    {
        bulletCount--;
        if (bulletCount <= 0)
        {
            StartCoroutine(EndGame());
        }
    }
    public static IEnumerator EndGame()
    {
        yield return new WaitForSeconds(gameOverDelay * Time.timeScale);
        Cursor.visible = true;
        SceneManager.LoadScene(2);
    }
    void ToggleFire()
    {
        canFire = !canFire;
    }
    void ClampAmmo()
    {
        bulletCount = Mathf.Clamp(bulletCount, 0, maxBullets);
    }
}
