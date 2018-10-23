﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GunController : MonoBehaviour {
    [Header("Aiming")]
    [SerializeField] Image crosshair;
    [SerializeField] float aimPointZ = 10;

    [Header("Bullet Spawning")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;

    [Header("Gun Customization")]
    [SerializeField] float bulletSpeed = 10;
    [SerializeField] float gunCooldown = 2;
    [SerializeField] float bulletLife = 5;

    [Header("Game Settings")]
    [SerializeField] int startingBullets = 2;


    public static int bulletCount;
    CanvasScaler canvasScaler;
    Camera mainCamera;
    float resolutionX;
    float resolutionY;
    bool canFire;
	// Use this for initialization
	void Start () {
        canvasScaler = crosshair.GetComponentInParent<CanvasScaler>();
        Cursor.visible = false;
        canFire = true;
        resolutionX = canvasScaler.referenceResolution.x;
        resolutionY = canvasScaler.referenceResolution.y;
        mainCamera = GetComponentInParent<Camera>();
        bulletCount = startingBullets;
	}
	
	// Update is called once per frame
	void Update () {
        MoveCrosshair();
        AimGun();
        FireGun();
	}

    void MoveCrosshair()
    {
        crosshair.rectTransform.anchoredPosition = new Vector2(Input.mousePosition.x * resolutionX / Screen.width,
            Input.mousePosition.y * resolutionY / Screen.height);
    }
    void AimGun() {
        var aimLocation = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, aimPointZ));
        transform.LookAt(aimLocation);
        bulletSpawn.LookAt(aimLocation);
    }
    void FireGun()
    {
        if(bulletCount <= 0) { return; }
        if (!canFire) { return; }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            var bulletRigid = bullet.GetComponent<Rigidbody>();
            bulletRigid.velocity = transform.forward * bulletSpeed;
            ToggleFire();
            Invoke("ToggleFire", gunCooldown);
            Destroy(bullet, bulletLife);
            UseAmmo();
        }
    }
    void UseAmmo()
    {
        bulletCount--;
        if(bulletCount <= 0)
        {
            Debug.Log("Out of ammo!");
        }
    }
    void ToggleFire()
    {
        canFire = !canFire;
    }
}