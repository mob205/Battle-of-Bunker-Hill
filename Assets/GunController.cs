using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GunController : MonoBehaviour {

    [SerializeField]Image crosshair;

    CanvasScaler canvasScaler;
	// Use this for initialization
	void Start () {
        canvasScaler = crosshair.GetComponentInParent<CanvasScaler>();
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        MoveCrosshair();
        AimGun();
	}

    void MoveCrosshair()
    {
        Debug.Log(Input.mousePosition.x + ", " + Input.mousePosition.y);
        //crosshair.rectTransform.anchoredPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        crosshair.rectTransform.anchoredPosition = new Vector2(Input.mousePosition.x * canvasScaler.referenceResolution.x / Screen.width,
            Input.mousePosition.y * canvasScaler.referenceResolution.y / Screen.height);
    }
    void AimGun()
    {
        transform.LookAt(Input.mousePosition);
    }
}
