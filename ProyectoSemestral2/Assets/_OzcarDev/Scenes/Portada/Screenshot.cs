using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    int i;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Foto");
            ScreenCapture.CaptureScreenshot("GameScreenShot"+i+".png",4);
            i++;
        }
    }
}
