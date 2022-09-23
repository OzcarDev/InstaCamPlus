using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Shot")&&gameManager.photoMode&&!gameManager.isPaused&&!gameManager.readingMode&&Globals.playerKeys.Contains("Camera"))
        {
            ScreenShotHandler.TakeScreenshot_Static(500, 500);
        }
    }
}
