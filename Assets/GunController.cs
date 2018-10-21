using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GunController : MonoBehaviour {

    [SerializeField]Image crosshair;

    CanvasScaler canvasScaler;
    Camera mainCamera;
    float resolutionX;
    float resolutionY;
	// Use this for initialization
	void Start () {
        canvasScaler = crosshair.GetComponentInParent<CanvasScaler>();
        //Cursor.visible = false;
        resolutionX = canvasScaler.referenceResolution.x;
        resolutionY = canvasScaler.referenceResolution.y;
        mainCamera = GetComponentInParent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        MoveCrosshair();
        AimGun();
	}

    void MoveCrosshair()
    {
        crosshair.rectTransform.anchoredPosition = new Vector2(Input.mousePosition.x * resolutionX / Screen.width,
            Input.mousePosition.y * resolutionY / Screen.height);
    }
    void AimGun() {
        //var aimLocation = new Vector3(2 * ((Input.mousePosition.x - (resolutionX / 2)) / resolutionX),
        //    2 * ((Input.mousePosition.y - (resolutionX / 2)) / canvasScaler.referenceResolution.y), 0);
        //Debug.Log(aimLocation);
        //transform.LookAt(aimLocation);
        //Debug.DrawRay(transform.position, aimLocation, Color.red, 0.1f);
        
        var aimLocation = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        transform.LookAt(aimLocation);
        Debug.Log(aimLocation + ", " + Input.mousePosition);
    }
}
